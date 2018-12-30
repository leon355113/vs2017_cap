(function (cibertec) {
    cibertec.video =
        {
        play: function (videoID) {
            var videoElement = document.getElementById(videoID);
               videoElement.play();
        },

        pause: function (videoID) {
            var videoElement = document.getElementById(videoID);
            videoElement.pause();
        }

        }
})(window.cibertec = window.cibertec || {}); 