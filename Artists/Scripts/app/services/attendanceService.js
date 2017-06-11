/*
 Implementing Revealing Module Pattern
*/

var AttendanceService = function () {

    var createAttendance = function (gigId, done, fail) {
        $.post("/api/attendances", { GigId: gigId })// debido a que el valor se debe pasar en el body, el parametro se debe pasar en un object literal
                           .done(done)
                           .fail(fail);
    }

    var deleteAttendance = function (gigId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + gigId,
            method: "DELETE"
        })
                .done(done)
                .fail(fail);
    }

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();//Immediately-Invoked Function Expression (IIFE)