(function ($) {
    $.fn.slide = function (settings) {
        //here settings object holds the values which have been passed as a parameter
        //in the slide function 
        var config = $.extend({
            //extends function replace the default values to the passed values
            delay: null, //3000
            fadeSpeed: null //1000
        }, settings);
        //holds the values
        var obj = $(this);
        //obj stores the reference of the current object which is $("#slideshow")
        var img = obj.children('img');
        //images are in the div container having id slideshow,
        //'div' act as a parent element and all the 'img' act as his childrens
        var count = img.length
        //count will have the no. of images present in the div element
        var i = 0;
        img.eq(0).show();
        //show the first image of the div container which is at position 0
        setInterval(function () {
            //it will be called continously at given interval (after 3000ms)
            //as config.delay having assigned value 3000ms
            img.eq(i).fadeOut(config.fadeSpeed);
            //here initially value of i = 0 then the image at position 0 will be fadeOut at given fadeSpeed
            i = (i + 1 == count) ? 0 : i + 1;
            setTimeout(show, 1000); //this function will be called after 1000ms = 1sec which is used to show the next image eg. at position 1
        }, config.delay);
        function show() {
            img.eq(i).fadeIn(config.fadeSpeed); //show the image with a given fadeSpeed
        }
    }
}(jQuery));