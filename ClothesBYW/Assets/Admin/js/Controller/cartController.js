var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            var sessionPL = $("#txtSessionName").val();
            window.location.href = "/Administrator/PurchaseOrders/AddProductIntoPO/" + sessionPL;
        });
        $('#btnSave').off('click').on('click', function () {
            window.location.href = "/Administrator/PurchaseOrders/Save";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtPurchaseQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    PurchaseQuantity: $(item).val(),
                    ProductLine: {
                        ProductLineID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Administrator/PurchaseOrders/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Administrator/PurchaseOrders/POCart";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/Administrator/PurchaseOrders/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Administrator/PurchaseOrders/POCart";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Administrator/PurchaseOrders/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Administrator/PurchaseOrders/POCart";
                    }
                }
            })
        });
    }
}
cart.init();