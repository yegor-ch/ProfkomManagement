$(document).ready(function () {

    // Selected members ID.
    var membersID = [];

    // Add row of selected member to table 'Members with Group'.
    $("input").on("click", AddGroupMembers);

    // Sending ID of selected members to server for adding members to Group.
    $("#btnAddGroupMembers").on("click", function () {
        // If any members is selected to adding to Group.
        if (membersID.length > 0) {

            // Data to send.
            var postData = {
                "GroupId": $("#groupId").text(),
                "MembersId": membersID
            };

            // Ajax post data.
            $.ajax({
                url: "/Groups/AddGroupMembers/",
                type: "POST",
                contentType: "application/json",
                traditional: true,
                dataType: "json",
                data: JSON.stringify(postData),
                success: function () {
                    window.location.reload(1);
                },
                error: function () {
                    window.location.reload(1);
                    console.log("error");
                }
            });
        } else {
            alert("Жоден студент не був обраний.");
        }
    });


    function AddGroupMembers() {
        // If user press checkbox to adding member to Group.
        if ($(this).prop('checked')) {
            // Chenge text label.
            $(this).siblings("label").text("Додано до групи");
            // Find closest <tr> near <checkbox> and clone 3 <td>.
            tdArr = $(this).closest("tr")
                .find("td").slice(0, 4).clone();
            // Create new row html element.
            newRow = $("<tr></tr>");
            // Paste cloned <td> to new row.
            newRow.append(tdArr);
            // Appended group.
            newRow.append("<td>" + $("#groupTitle").text() + "</td>")

            // Appended row to table.
            $('#tableWithMembers tbody').append(newRow);

            // Save selected member id.
            var id = $(this).closest("tr").find("td:first").text();
            membersID.push(id);
        }
        else {
            
            $(this).siblings("label").text("Додати до групи");
            // Get hidden ID of current checked member.
            var id = $(this).closest("tr").find("td:first").text();

            var index = membersID.indexOf(id);
            membersID.splice(index, 1);

            $('#tableWithMembers .hiddenId:contains(' + id + ')').closest("tr").remove();
        }
    }
});

