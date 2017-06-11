
/*
Implementing Revealing Module Pattern
*/
var GigDetailsController = function (followingService) {
    var followBotton;

    var init = function () {
        $(".js-toggle-follow").click(toggleFollowing);
    }

    var toggleFollowing = function (e) {
        followBotton = $(e.target);

        var followeeId = followBotton.attr("data-user-id");

        if (followBotton.hasClass("btn-default")) 
            followingService.createFollowing(followeeId, done, fail);
        else 
            followingService.deleteFollowing(followeeId, done, fail);
    };

    var done = function () {
        var text = (followBotton.text() == "Follow") ? "Following" : "Follow";
        followBotton.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something failed!");
    };

    return {
        init: init
    }

}(FollowingService);
