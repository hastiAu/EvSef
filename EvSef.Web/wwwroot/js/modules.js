
/*remove-ajax */

$("[remove-ajax]").on('click', function (e) {
    e.preventDefault();
    var itemId = $(this).attr("remove-ajax-item-id");
    var itemUrl = $(this).attr("href");

    swal({
        title: 'Warning',
        text: "Are you Sure ?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((result) => {
        if (result.value) {

            $.post(itemUrl).then(function (resultMessage) {

                if (resultMessage != null) {

                    swal({
                        title: "Attention!",
                        text: resultMessage.text,
                        type: "info"
                    }).then(resultCommand => {


                        if (resultMessage.statusCode == 200) {

                            if (itemId !== null && itemId !== "" && itemId !== undefined) {

                                $('[remove-ajax-item="' + itemId + '"]').hide(300);

                            } else {
                                window.location.reload();
                            }

                        }


                    });

                }

            });

        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('Info', 'Operation Was Canceled!', 'error');
        }
    });

});


