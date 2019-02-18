(function (app) {
    app.helpers =
    {
        replaceAll : function (string, find, replace) {
            var result = string.replace(
                new RegExpr(find, 'g'), replace
            );

            return result;
        },
        getAniosArray: function(anioInicio) {
                var hoy = new Date();
                var anios = [];
                for (i = anioInicio; i <= hoy.getFullYear(); i++) {
                    anios.push(i);
                }

                return anios;
        },
        BloquearControls : function()
        {
            $("input,select,button,textarea").attr("disabled", "disabled");
        },
        DesbloquearControls: function() {
            $("input,select,button,textarea").removeAttr("disabled");
        },
        SetObjectLocalStorage: function (jsObject, keyStorage) {
            var json = JSON.stringify(jsObject);
            localStorage.setItem(keyStorage, json);

        },
        GetObjectLocalStorage: function (keyStorage) {
            var json = localStorage.getItem(keyStorage);
            return JSON.parse(json);
        },
        showModal: function (containerId,url) {            
            //Invocando a la vista utilizando AJAX
            $.get(url,
                function (html) {
                    $('#' + containerId + " .modal-body").html(html);
                    $("#" + containerId).modal("show");
                }
            );
        },
        closeModal(modalId) {
            $("#" + modalId).modal("hide");
        }
    }
})(window.app = window.app || {});