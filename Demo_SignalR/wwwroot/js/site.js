$(() => {
    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();

    connection.start().then(function () {
        console.log("SignalR Connected");

        connection.on("ReceiveCreateField", function (field) {
            LoadData();
        });

        connection.on("ReceiveUpdatedField", function (field) {
            LoadData();
        });

        connection.on("ReceiveDeletedField", function (field) {
            LoadData();
        });

        LoadData();
    }).catch(function (err) {
        return console.error(err.toString());
    });

    function LoadData() {
        var tr = '';
        $.ajax({
            url: '/BadmintonFieldPages/Index?handler=Fields', 
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr +=
                        `<tr>
                        <td> ${v.badmintonFieldName} </td>
                        <td> ${v.address} </td>
                        <td> ${v.description} </td>
                        <td> ${v.startTime} </td>
                        <td> ${v.endTime} </td>
                        <td> ${v.isActive} </td>
                        <td>
                            <a href='../BadmintonFieldPages/Edit?id=${v.badmintonFieldId}'> Edit </a>
                            <a href='../BadmintonFieldPages/Details?id=${v.badmintonFieldId}'> Details </a>
                            <a href='../BadmintonFieldPages/Delete?id=${v.badmintonFieldId}'> Delete </a>
                        </td>
                    </tr>`;
                });

                $('#tableBody').html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }

});
