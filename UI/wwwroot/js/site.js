document.addEventListener('DOMContentLoaded', function () {
    // Handle click event for Home menu
    document.getElementById('homeMenu').addEventListener('click', function () {
        window.location.href = '/';
    });

    // Handle click event for Login menu
    document.getElementById('loginMenu').addEventListener('click', function () {
        window.location.href = '/Account/Login';
    });

    // Handle click event for Register menu
    document.getElementById('registerMenu').addEventListener('click', function () {
        window.location.href = '/Account/Register';
    });

    // Handle click event for Category menus
    document.querySelectorAll('.categoryMenu').forEach(function (element) {
        element.addEventListener('click', function () {
            var categoryId = this.getAttribute('data-category-id');
            window.location.href = '/Product/List?categoryId=' + categoryId;
        });
    });
});