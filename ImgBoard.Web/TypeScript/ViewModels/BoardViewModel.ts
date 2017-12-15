namespace ViewModels {
    export class BoardViewModel {
        Action: KnockoutObservable<string>;
        Images: KnockoutObservableArray<FrontModels.Image>;
        SearchText: KnockoutObservable<string>;
        Matches: KnockoutObservableArray<FrontModels.Category>;
        
        Term: KnockoutComputed<string>;

        SearchSettings: KnockoutObservableArray<InternalModels.SearchSetting>;

        Search: () => void;
        FetchImagesByMatch: (match: FrontModels.Category) => void;
        RemoveSearchSetting: (searchSetting: InternalModels.SearchSetting) => void;

        ApplySearchResult: (action: string, images: Array<Models.IImage>, timeStart: number) => void;
        MatchesSearch: (term: string) => void;

        constructor(images: Array<Models.IImage>) {
            this.Action = ko.observable("All images");
            this.SearchText = ko.observable("");
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));
            this.Matches = ko.observableArray([]);

            this.SearchSettings = ko.observableArray([]);

            this.Term = ko.pureComputed<string>(this.SearchText)
                .extend({ rateLimit: { method: "notifyWhenChangesStop", timeout: 400 } });
            this.Term.subscribe((term) => {
                let timeStart = Date.now();
                if (term.length === 0) {
                    $('#search-matches').hide();
                } else {
                    this.MatchesSearch(term);
                }
            }, this);

            this.Search = () => {
                let timeStart = Date.now();
                
                let term = this.SearchText();

                if (term.length === 0) {
                    $('#main-throbber').show();
                    $('.images-grid').hide();

                    ApiRequests.GetImagesRequest(images => {
                        this.ApplySearchResult("All images", images, timeStart);
                    });
                } else {
                    this.MatchesSearch(term);
                }
            };

            this.FetchImagesByMatch = (match: FrontModels.Category) => {
                let timeStart = Date.now();
                
                this.SearchText("");

                this.SearchSettings.push({
                    Id: match.Id,
                    Type: "Category",
                    Value: match.Title
                });

                $('#search-matches').hide();
                $('#main-throbber').show();
                $('.images-grid').hide();

                ApiRequests.GetImagesByCategory(match.Id, images => {
                    this.ApplySearchResult("Matches for : " + match.Title, images, timeStart);
                });
            };

            this.RemoveSearchSetting = (searchSetting: InternalModels.SearchSetting) => {
                this.SearchSettings.remove(searchSetting);
            };

            this.ApplySearchResult = (
                action: string,
                images: Array<Models.IImage>,
                timeStart: number
            ) => {
                this.Action(action);
                this.Images(images.map(el => new FrontModels.Image(el)));
                Util.SetMinimumTimeout(timeStart, 500, ViewsCode.ResetBoardDom);
            };

            this.MatchesSearch = (term: string) => {
                ApiRequests.GetMatchingCategories(term, categories => {
                    let result = categories
                        .map(el => new FrontModels.Category(el))
                        .filter(el => {

                            let existing = ko.utils.arrayFirst(this.SearchSettings(), (item: InternalModels.SearchSetting) => {
                                return item.Value === el.Title;
                            });

                            return existing === null;
                        });

                    this.Matches(result);
                    $('#search-matches').show();
                });
            }
        }
    }
}