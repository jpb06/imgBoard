namespace ViewsCode {
    export function Board() {
        let timeStart = Date.now();
        ApiRequests.GetImagesRequest(images => {
            ko.applyBindings(new ViewModels.BoardViewModel(images));

            Util.SetMinimumTimeout(timeStart, 500, this.SetupBoardDom);
        });
    }

    export function ResetBoardDom() {
        $('#grid-content').masonry('destroy');
        ViewsCode.SetupBoardDom();
    }

    export function SetupBoardDom() {
        $('.images-grid').imagesLoaded().progress(() => {
            $('#grid-content').masonry({
                itemSelector: '.grid-item',
                columnWidth: '.grid-sizer',
                percentPosition: true
            });
        });
        $('#main-throbber').hide();
        $('.images-grid').fadeIn();
    }
}