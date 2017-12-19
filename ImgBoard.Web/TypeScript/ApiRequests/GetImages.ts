namespace ApiRequests {
    export function GetImages(parameters: ApiModels.GetImagesParameters, done: (images: Array<Models.IImage>) => any, fail?: () => any) {
        let settings = {
            url: '/imgboard/siteapi/getimages',
            type: 'POST',
            dataType: 'json', 
            data: parameters
        };

        $.ajax(settings)
            .done(function (images: Array<Models.IImage>) {

                return done(images);
            })
            .fail(function (data) {
                if (fail != null) {
                    fail();
                }
            });
    }
}