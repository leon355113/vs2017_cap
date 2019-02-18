(function (app) {
    app.CategoriaView =
        {
        RefreshLista: function () {
            $(".buscar").click();
            app.helpers.closeModal("CategoriaCreatePopup");
            }
        }
})(window.app = window.app || {});