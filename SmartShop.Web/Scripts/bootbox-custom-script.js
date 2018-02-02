$(document).ready(function(){
    /*=========================Confirm Box================================*/
    $('.bootbox_confirm_delete').click(function (event) {
        event.preventDefault();
        var targetUrl = $(this).attr("href");

        bootbox.confirm({
            title: "Confirmation",
            message: "Are you sure to delete this item?",
            size: 'small',
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> No',
                    className: 'btn-warning'
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Yes',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    window.location = targetUrl;
                }
            }
        });
    });
/*=========================/Confirm Box================================*/
});