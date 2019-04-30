(function (cibertec) {
    cibertec.Index =
        {
            currentYear: function () {
                var today = new Date();
                return today.getFullYear();
            }
        }
})(window.cibertec = window.cibertec || {});