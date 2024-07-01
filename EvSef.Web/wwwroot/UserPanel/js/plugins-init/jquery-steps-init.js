(function ($) {
    "use strict";

    var form = $("#step-form-horizontal");
    form.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        autoFocus: true,
        onStepChanging: function (event, currentIndex, newIndex) {
            // Address Step
            if (newIndex === 2) {
                // Save selected contact info ID in session
                var selectedContactInfoId = $('input[name="selectedContactInfoId"]:checked').val();
                if (selectedContactInfoId) {
                    $.ajax({
                        url: '/UserPanel/Home/SaveSelectedContactInfoIdInSession',
                        type: 'POST',
                        data: $('#addressSession').serialize(),
                        success: function (response) {
                            if (response.success) {
                                // Optionally, you can perform UI updates here
                                /*  alert(response.message); // Show success message*/
                                $('html, body').animate({ scrollTop: 0 }, 'fast');

                                // Get address details from session
                                $.ajax({
                                    url: '/UserPanel/Home/GetAddressDetailsFromSession',
                                    type: 'GET',
                                    success: function (addressDetailsResponse) {
                                        console.log('Address Details Received:', addressDetailsResponse.addressDetails);

                                        if (addressDetailsResponse.success) {
                                            // Update UI with received details
                                            $('#reviewAddress').val(addressDetailsResponse.addressDetails.address);
                                            $('#reviewState').val(addressDetailsResponse.addressDetails.state);
                                            $('#reviewDistrict').val(addressDetailsResponse.addressDetails.district);
                                            $('#reviewZipCode').val(addressDetailsResponse.addressDetails.zipCode);
                                        } else {
                                            console.error('Error: ', addressDetailsResponse.message);
                                            ShowMessage(addressDetailsResponse.message);
                                        }
                                    },
                                    error: function (xhr, status, error) {
                                        console.error('Error: ', status, error);
                                        ShowMessage('Error', 'Error fetching address', 'error');
                                    }
                                });
                            } else {
                                ShowMessage(response.message); // Show any error message received from server
                            }
                        },
                        error: function () {
                            ShowMessage('Error', 'Error saving delivery and payment details', 'error');
                        }
                    });
                } else {
                    ShowMessage('Error', 'Please choose an address.', 'error');
                    return false; // Prevent moving to the next step
                }
            }

            // Delivery & Payment Method Step
            if (newIndex === 3) {
                // Save delivery and payment details via AJAX
                $.ajax({
                    url: '/UserPanel/SaveDeliveryAndPaymentDetails',
                    method: 'POST',
                    data: $('#deliveryPaymentForm').serialize(),
                    success: function (response) {
                        if (response.success) {
                            console.log('Successfully saved delivery and payment details.');
                            ShowMessage('Delivery and payment details saved successfully.');
                            $('html, body').animate({ scrollTop: 0 }, 'fast');

                            // Fetch updated delivery and payment details after saving
                            $.ajax({
                                url: '/UserPanel/Home/GetDeliveryAndPaymentDetailsFromSession',
                                method: 'GET',
                                success: function (deliveryAndPaymentDetails) {
                                    console.log('Successfully fetched delivery and payment details.');
                                    var deliveryDate = deliveryAndPaymentDetails.deliveryDate.split('T')[0]; // Split Date without Hour
                                    var paymentMethod = $('input[name="CartDeliveryDateViewModel.PaymentMethod"]:checked').val();

                                    // Update UI with fetched details
                                    $('#deliveryDate').val(deliveryDate);
                                    $('#deliveryTime').val(deliveryAndPaymentDetails.deliveryTime);
                                    $('#details').val(deliveryAndPaymentDetails.details);
                                    $('#paymentMethod').val(paymentMethod);
                                },
                                error: function () {
                                    console.log('Error fetching delivery and payment details.');
                                    ShowMessage('Error', 'Error fetching delivery and payment details', 'error');
                                }
                            });
                        } else {
                            ShowMessage('Error', 'Error saving details', 'error');
                        }
                    },
                    error: function () {
                        ShowMessage('Error', 'An error occurred while saving details', 'error');
                    }
                });
            }

            form.validate().settings.ignore = ":disabled,:hidden";
            return form.valid();
        },

        onStepChanged: function (event, currentIndex, priorIndex) {
            // Optional: code to run when step changes
        },

        onFinished: function (event, currentIndex) {
            // این تابع به متد myFinishFunction هدایت می‌شود
            myFinishFunction();
        }
    });

    // Additional form configurations (form2 and form3)
    var form2 = $("#step-form-tab");
    form2.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        enableFinishButton: false,
        enablePagination: false,
        enableAllSteps: true,
        titleTemplate: "#title#"
    });

    var form3 = $('#step-form-vertical');
    form3.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical"
    });

    function myFinishFunction() {
        // اینجا عملیاتی که می‌خواهید پس از کلیک بر روی دکمه Finish انجام دهید را قرار دهید
        console.log("دکمه Finish کلیک شد!");
        var postData = {
            cartAddresses: {
                Address: $('#reviewAddress').val(),
                State: $('#reviewState').val(),
                District: $('#reviewDistrict').val(),
                ZipCode: $('#reviewZipCode').val()
            },
            cartDeliveryDateViewModel: {
                DeliveryDate: $('#deliveryDate').val(),
                DeliveryTime: $('#deliveryTime').val(),
                Details: $('#details').val(),
                PaymentMethod: $('#paymentMethod').val()
            },
            Tax: parseFloat($('#tax').val()),
    
            TotalPrice: parseFloat($('#totalPrice').text()),
            FinalPrice: parseFloat($('#finalPrice').text())
        };

        var postDataJson = JSON.stringify(postData);

        console.log('postData', postData);

        $.ajax({
            url: '/UserPanel/Home/CheckOut',
            type: 'POST',
            contentType: 'application/json',
            data: postDataJson,
            success: function (response) {
                console.log('Checkout successful:', response);
            },
            error: function (xhr, status, error) {
                console.error('Checkout failed:', status, error);
                alert('Error sending data. Please try again.');
            }
        });
    
    }

})(jQuery);
