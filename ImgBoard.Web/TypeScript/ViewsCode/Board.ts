namespace ViewsCode {
    export function Board() {
        let timeStart = Date.now();
        ApiRequests.GetImagesRequest(images => {
            ko.applyBindings(new ViewModels.BoardViewModel(images));

            Util.SetMinimumTimeout(timeStart, 500, this.SetupBoardDom);
        });
    }

    export function ResetBoardDom() {
        $('#gridContent').masonry('destroy');
        ViewsCode.SetupBoardDom();
    }

    export function SetupBoardDom() {
        $('.imagesGrid').imagesLoaded().progress(() => {
            $('#gridContent').masonry({
                itemSelector: '.grid-item',
                columnWidth: '.grid-sizer',
                percentPosition: true
            });
        });
        $('#mainThrobber').hide();
        $('.imagesGrid').fadeIn();
    }
}