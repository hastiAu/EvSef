using EvSef.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EvSef.Domain.Entities.Food;
using EvSef.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using EvSef.Domain.Entities.Order;
using EvSef.Domain.Entities.OrderDetails;
using EvSef.Domain.Entities.UserType;
using EvSef.Domain.ViewModels.Cart;
using DocumentFormat.OpenXml.Spreadsheet;
using EvSef.Domain.Entities.ContactInfo;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace EvSef.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        #region Constructor

        private readonly EvSefDbContext _context;

        public OrderRepository(EvSefDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Show CartItem



        public async Task<CartItemViewModel> GetItemByChefFoodId(int chefFoodId)
        {

            var weekdayFood = await _context.WeekDayFoods
                .Where(wfd => wfd.IsActive)
                .Where(wfd => wfd.IsActive)
                .Include(wfd => wfd.ChefFood)
                .ThenInclude(wfd => wfd.Food)
                .Include(wfd => wfd.ChefFood)
                .ThenInclude(wfd => wfd.ChefFoodPrices)
                .FirstOrDefaultAsync(f => f.ChefFoodId == chefFoodId);

            if (weekdayFood != null)
            {

                return new CartItemViewModel
                {
                    ChefFoodId = weekdayFood.ChefFoodId,
                    FoodTitle = weekdayFood.ChefFood.Food.FoodTitle,
                    ChefFoodsPrice = weekdayFood.ChefFood.ChefFoodPrices.Any() ? weekdayFood.ChefFood.ChefFoodPrices.FirstOrDefault().ChefFoodsPrice : 0,
                    ImageFood = weekdayFood.ChefFood.Food.ImageFood,
                    Quantity = 1, // مقدار پیش‌فرض برای یک آیتم جدید

                };
            }
            else
            {
                return null;
            }

        }



        public async Task<List<CartAddressViewModel>> GetClientContactInfoById(int clientId)
        {
            var addresses = await _context.ContactInfos
                .Where(ci => ci.RelatedId == clientId)
                .ToListAsync();

            // Create a List for show
            List<CartAddressViewModel> cartAddresses = new List<CartAddressViewModel>();

            //Need List so Foreach:
            foreach (var address in addresses)
            {
                var location = await _context.ContactLocations
                    .Include(l => l.Parent)
                    .FirstOrDefaultAsync(l => l.LocationId == address.LocationId);
                //new var from query
                var state = location?.Parent;
                var district = location;

                // Add  all details  from 2 query to CartAddressViewModel
                cartAddresses.Add(new CartAddressViewModel
                {
                    Address = address.ContactInfoAddress,
                    LocationId = address.LocationId,
                    State = state?.StateName,
                    District = district?.StateName,
                    ZipCode = address.ContactInfoZipCode,
                    ContactInfoId = address.ContactInfoId,

                });
            }

            //return List
            return cartAddresses;
        }

        public async Task CreateNewContactInfoByClient(ContactInfo contactInfo)
        {
            await _context.AddAsync(contactInfo);
        }

        public async Task<bool> AddressIsExists(string address)
        {
            return await _context.ContactInfos.AnyAsync(ad => ad.ContactInfoAddress == address);
        }

        public async Task<RelatedType> GetRelatedTypeByClientId(int clientId)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.RelatedId == clientId);
            if (client == null)
            {
                throw new Exception("Client not found");
            }
            return client.RelatedType;
        }

        public CartAddressViewModel GetAddressDetailsById(int contactInfoId)
        {
            var contactInfo = _context.ContactInfos.FirstOrDefault(ci => ci.ContactInfoId == contactInfoId);

            if (contactInfo != null)
            {
                // Fetch State and District based on LocationId from ContactLocation
                var location = _context.ContactLocations.Include(l => l.Parent)
                    .FirstOrDefault(l => l.LocationId == contactInfo.LocationId);

                if (location != null)
                {
                    // Determine if it's a state or district
                    string stateName;
                    if (location.ParentId == null)
                    {
                        // It's a state
                        stateName = location.StateName;
                    }
                    else
                    {
                        // It's a district, find its parent state
                        var parentState = _context.ContactLocations
                            .FirstOrDefault(l => l.LocationId == location.ParentId);
                        stateName = parentState != null ? parentState.StateName : null;
                    }

                    // Assign values to ViewModel
                    var addressDetails = new CartAddressViewModel
                    {
                        ContactInfoId = contactInfo.ContactInfoId,
                        Address = contactInfo.ContactInfoAddress,
                        State = stateName,
                        District = location.StateName,
                        ZipCode = contactInfo.ContactInfoZipCode
                    };

                    return addressDetails;
                }
            }

            return null;
        }




        #endregion



        #region DisposeAsync
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        #endregion

        #region SaveChanges
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
