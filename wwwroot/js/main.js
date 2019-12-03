$(document).ready(function () {
    //LoadFacultiesList();
    $("#facultylist").on("change", function () {
        LoadGroupList(this.value);
    });
    $(".isScholarship").on("change", function () {
        CheckIsScholarship();
    });
});

function LoadFacultiesList() {
    $listOfFaculties = $("#facultylist");
    $.ajax({
        url: "/faculties/facultiesjsonlist",
        type: "GET",
        traditional: true,
        success: function (result) {
            $listOfFaculties.empty();
            $listOfFaculties.append('<option value="0">' + "Please select" + '</option>');
            $.each(result, function (item) {
                console.log(item["id"] + " " + item["title"]);
                $listOfFaculties.append('<option value="' + item["id"] + '">' + item["title"] + '</option>');
            });
        },
        error: function () {
            console.log("Can't to retrive data");
        }
    });
}

function LoadGroupList(id) {
    $groupsList = $("#groupsList");
    $.ajax({
        url: "/faculties/groupsapi/" + id,
        type: "GET",
        traditional: true,
        success: function (result) {
            console.log(result);
            $groupsList.empty();
            $groupsList.append('<option value="0">' + "Оберіть групу" + '</option>');
            $.each(result, function (i, item) {
                console.log(item["id"] + " " + item["title"]);
                $groupsList.append('<option value="' + item["id"] + '">' + item["title"] + '</option>');
            });
        },
        error: function () {
            console.log("Can't to retrive data")
        }
    });
}

function CheckIsScholarship() {

    $checkBox = $(".isScholarship");

    if ($checkBox.prop('checked')) {
        $("#scholarhipLabel").text("Отримує стипендію");
    } else {
        $("#scholarhipLabel").text("Не отримує стипендію");
    }
}