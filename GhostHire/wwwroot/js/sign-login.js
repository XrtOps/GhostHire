document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('profilePic').addEventListener('click', function () {
        document.getElementById('dropDownContent').classList.toggle('show');
    });

    window.onclick = function (event) {
        if (!event.target.matches('#profilePic')) {
            var dropdowns = document.getElementsByClassName('drop-down');
            for (var i = 0; i < dropdowns.length; i++) {
                var openDropdown = dropdowns[i];
                if (openDropdown.classList.contains('show')) {
                    openDropdown.classList.remove('show');
                }
            }
        }
    }
});