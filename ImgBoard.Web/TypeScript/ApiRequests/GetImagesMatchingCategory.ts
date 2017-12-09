namespace ApiRequests {
    export function GetImagesMatchingCategory(term: string,
                                              done: (images: Array<Models.IImage>) => any, fail?: () => any) {
        let settings = {
            url: '/imgboard/siteapi/getimagesmatchingcategory/'+term,
            type: 'GET',
            dataType: 'json'
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