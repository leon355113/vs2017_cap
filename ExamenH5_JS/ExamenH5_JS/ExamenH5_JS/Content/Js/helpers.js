(function (cibertec) {
    cibertec.helpers =
        {
            replaceAll: function (string, find, replace) {
                var result = string.replace(
                    new RegExp(find, 'g'), replace
                );

                return result;
            },

            getAniosArray: function (anioInicio) {
                var hoy = new Date();
                var anios = [];
                for (i = anioInicio; i <= hoy.getFullYear(); i++) {
                    anios.push(i); //Agregar elementos a un arreglo
                }

                return anios;
            },

            BloquearControls: function () {
                $("input,select,button,textarea").attr("disabled", "disabled");
            },

            DesbloquearControls: function () {
                $("input,select,button,textarea").removeAttr("disabled");
            },
            //Serializar y almacenar
            SetObjectLocalStorage: function (valueObject, keyStorage) {
                var json = JSON.stringify(valueObject);
                localStorage.setItem(keyStorage, json);
            },
            //Descerializar y retornar
            GetObjectLocalStorage: function (keyStorage) {
                var json = localStorage.getItem(keyStorage);
                console.log(typeof keyStorage);//object
                console.log(typeof json); //string

                return JSON.parse(json);
            },
            //------------------------------funciones adicionales-----------------------//
            //validar formato de fecha
            validarFormatoFecha: function (campo) {
                var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
                if ((campo.match(RegExPattern)) && (campo != '')) {
                    return true;
                } else {
                    return false;
                }
            },
            existeFecha: function (fecha) {
                var fechaf = fecha.split("/");
                var day = fechaf[0];
                var month = fechaf[1];
                var year = fechaf[2];
                var date = new Date(year, month, '0');
                if ((day - 0) > (date.getDate() - 0)) {
                    return false;
                }
                return true;
            },
            existeFecha2: function (fecha) {
                var fechaf = fecha.split("/");
                var d = fechaf[0];
                var m = fechaf[1];
                var y = fechaf[2];
                return m > 0 && m < 13 && y > 0 && y < 32768 && d > 0 && d <= (new Date(y, m, 0)).getDate();
            },
            //---------------------validar RUC-------------------------------------//
            //Handler para el evento cuando cambia el input
            //Elimina cualquier caracter espacio o signos habituales y comprueba validez
            validarInput: function (input) {
                var ruc = input.value.replace(/[-.,[\]()\s]+/g, ""),
                    resultado = document.getElementById("resultado"),
                    existente = document.getElementById("existente"),
                    valido;

                existente.innerHTML = "";

                //Es entero?    
                if ((ruc = Number(ruc)) && ruc % 1 === 0
                    && rucValido(ruc)) { // ⬅️ ⬅️ ⬅️ ⬅️ Acá se comprueba
                    valido = "Válido";
                    resultado.classList.add("ok");
                    obtenerDatosSUNAT(ruc);
                } else {
                    valido = "No válido";
                    resultado.classList.remove("ok");
                }

                resultado.innerText = "RUC: " + ruc + "\nFormato: " + valido;
            },

            // Devuelve un booleano si es un RUC válido
            // (deben ser 11 dígitos sin otro caracter en el medio)
            rucValido: function (ruc) {
                //11 dígitos y empieza en 10,15,16,17 o 20
                if (!(ruc >= 1e10 && ruc < 11e9
                    || ruc >= 15e9 && ruc < 18e9
                    || ruc >= 2e10 && ruc < 21e9))
                    return false;

                for (var suma = -(ruc % 10 < 2), i = 0; i < 11; i++ , ruc = ruc / 10 | 0)
                    suma += (ruc % 10) * (i % 7 + (i / 7 | 0) + 1);
                return suma % 11 === 0;

            },

            //Buscar datos del RUC y si existe
            obtenerDatosSUNAT: function (ruc) {
                //Init
                var url = "https://cors-anywhere.herokuapp.com/wmtechnology.org/Consultar-RUC/?modo=1&btnBuscar=Buscar&nruc=" + ruc,
                    existente = document.getElementById("existente"),
                    xhr = false;
                if (window.XMLHttpRequest) //Crear XHR
                    xhr = new XMLHttpRequest();
                else if (window.ActiveXObject)
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                else return false;
                //handler para respuesta
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4 && xhr.status == 200) { //200 OK
                        var doc = document.implementation.createHTMLDocument()
                            .documentElement,
                            res = "",
                            txt, campos,
                            ok = false;

                        doc.innerHTML = xhr.responseText;
                        //Sólo el texto de las clases que nos interesa
                        campos = doc.querySelectorAll(".list-group-item");
                        if (campos.length) {
                            for (txt of campos)
                                res += txt.innerText + "\n";
                            //eliminar blancos por demás
                            res = res.replace(/^\s+\n*|(:) *\n| +$/gm, "$1");
                            //buscar si está el texto "ACTIVO" en el estado
                            ok = /^Estado: *ACTIVO *$/m.test(res);
                        } else
                            res = "RUC: " + ruc + "\nNo existe.";

                        //mostrar el texto formateado
                        if (ok)
                            existente.classList.add("ok");
                        else
                            existente.classList.remove("ok");
                        existente.innerText = res;
                    }
                } //falta verificar errores en conexión
                xhr.open("POST", url, true);
                xhr.send(null);
            },
            //---------------------valida dni//
            nif: function (dni) {
                var numero
                var letr
                var letra
                var expresion_regular_dni

                expresion_regular_dni = /^\d{8}[a-zA-Z]$/;

                if (expresion_regular_dni.test(dni) == true) {
                    numero = dni.substr(0, dni.length - 1);
                    letr = dni.substr(dni.length - 1, 1);
                    numero = numero % 23;
                    letra = 'TRWAGMYFPDXBNJZSQVHLCKET';
                    letra = letra.substring(numero, numero + 1);
                    if (letra != letr.toUpperCase()) {
                        alert('Dni erroneo, la letra del NIF no se corresponde');
                    } else {
                        alert('Dni correcto');
                    }
                } else {
                    alert('Dni erroneo, formato no válido');
                }
            },

            //Solo permite introducir números.
            soloNumeros: function (e) {
                var key = window.event ? e.which : e.keyCode;
                if (key < 48 || key > 57) {
                    //Usando la definición del DOM level 2, "return" NO funciona.
                    e.preventDefault();
                }
            },

            ValidarTJ: function (numero_tarjeta) {
                var cadena = numero_tarjeta.toString();
                var longitud = cadena.length;
                var cifra = null;
                var cifra_cad = null;
                var suma = 0;
                for (var i = 0; i < longitud; i += 2) {
                    cifra = parseInt(cadena.charAt(i)) * 2;
                    if (cifra > 9) {
                        cifra_cad = cifra.toString();
                        cifra = parseInt(cifra_cad.charAt(0)) +
                            parseInt(cifra_cad.charAt(1));
                    }
                    suma += cifra;
                }
                for (var i = 1; i < longitud; i += 2) {
                    suma += parseInt(cadena.charAt(i));
                }

                if ((suma % 10) == 0) {
                    alert("Número de tarjeta correcto");
                } else {
                    alert("El número de tarjeta no es válido");
                }
            },
            //------------------------------valida en JQuiery------------------------------------------//

            formateafecha: function (fecha) {
                var primerslap = false;
                var segundoslap = false;
                var long = fecha.length;
                var dia;
                var mes;
                var ano;
                if ((long >= 2) && (primerslap == false)) {
                    dia = fecha.substr(0, 2);
                    if ((IsNumeric(dia) == true) && (dia <= 31) && (dia != "00")) { fecha = fecha.substr(0, 2) + "/" + fecha.substr(3, 7); primerslap = true; }
                    else { fecha = ""; primerslap = false; }
                }
                else {
                    dia = fecha.substr(0, 1);
                    if (IsNumeric(dia) == false) { fecha = ""; }
                    if ((long <= 2) && (primerslap = true)) { fecha = fecha.substr(0, 1); primerslap = false; }
                }
                if ((long >= 5) && (segundoslap == false)) {
                    mes = fecha.substr(3, 2);
                    if ((IsNumeric(mes) == true) && (mes <= 12) && (mes != "00")) { fecha = fecha.substr(0, 5) + "/" + fecha.substr(6, 4); segundoslap = true; }
                    else { fecha = fecha.substr(0, 3);; segundoslap = false; }
                }
                else { if ((long <= 5) && (segundoslap = true)) { fecha = fecha.substr(0, 4); segundoslap = false; } }
                if (long >= 7) {
                    ano = fecha.substr(6, 4);
                    if (IsNumeric(ano) == false) { fecha = fecha.substr(0, 6); }
                    else { if (long == 10) { if ((ano == 0) || (ano < 1900) || (ano > 2100)) { fecha = fecha.substr(0, 6); } } }
                }
                if (long >= 10) {
                    fecha = fecha.substr(0, 10);
                    dia = fecha.substr(0, 2);
                    mes = fecha.substr(3, 2);
                    ano = fecha.substr(6, 4);
                    // Año no viciesto y es febrero y el dia es mayor a 28 
                    if ((ano % 4 != 0) && (mes == 02) && (dia > 28)) { fecha = fecha.substr(0, 2) + "/"; }
                }
                return (fecha);
            },
            IsNumeric: function (valor) {
                var log = valor.length; var sw = "S";
                for (x = 0; x < log; x++) {
                    v1 = valor.substr(x, 1);
                    v2 = parseInt(v1);
                    //Compruebo si es un valor numérico 
                    if (isNaN(v2)) { sw = "N"; }
                }
                if (sw == "S") { return true; } else { return false; }
            }

        }
})(window.cibertec = window.cibertec || {}); 

