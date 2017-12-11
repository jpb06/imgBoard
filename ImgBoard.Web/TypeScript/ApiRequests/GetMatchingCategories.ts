namespace ApiRequests {
    export function GetMatchingCategories(
        term: string,
        done: (categories: Array<Models.ICategory>) => any, fail?: () => any
    ) {
        let settings = {
            url: '/imgboard/siteapi/getmatchingcategories/' + term,
            type: 'GET',
            dataType: 'json'
        };

        $.ajax(settings)
            .done(function (categories: Array<Models.ICategory>) {

                return done(categories);
            })
            .fail(function (data) {
                if (fail != null) {
                    fail();
                }
            });
    }
}