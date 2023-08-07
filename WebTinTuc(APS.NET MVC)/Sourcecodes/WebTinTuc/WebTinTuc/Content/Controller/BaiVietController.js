var user = {
    init: function () {
      
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: '/BaiViet/ChangeStatus',
                data: { id: id },
                type :"POST",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    if (response.TrangThai == true) {
                        btn.text('Duyệt');

                    }
                    else {
                        btn.text('Chưa Duyệt');
                    }
                }
            });
        });
    }
}
user.init();

