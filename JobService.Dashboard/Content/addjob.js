function addHttpJob() {
    try {
        let jobTypeSelection = document.getElementById("httpJobType");
        let jobType = jobTypeSelection.options[jobTypeSelection.selectedIndex].value;
        let endpoint = document.getElementById("httpJobEndpoint").value;
        let bodyTextUgly = document.getElementById("httpJobBody").value;
        var bodyTextObj = JSON.parse(bodyTextUgly);

        var headerObj = {};
        let headerContainer = document.getElementById("httpHeaders");
        for (var i = 0; i < headerContainer.childElementCount; i++) {
            let headerKey = headerContainer.children[i].getElementsByTagName('input').key.value
            let headerValue = headerContainer.children[i].getElementsByTagName('input').value.value
            headerObj[headerKey] = headerValue;
        };

        let name = document.getElementById("httpJobName").value;
        let duration = document.getElementById("httpJobDuration").value;
        let delayed = document.getElementById("httpJobDelayed").value;

        if (delayed === "" || delayed === null || delayed === undefined || (!isNaN(delayed) && delayed.toString().indexOf('.') != -1)) {
            delayed = '0.0';
        }
        
        getDropdownValues("httpTags-tags", function (selections) {

            let body = {
                "HttpJobs": [
                    {
                        "endpoint": endpoint,
                        "body": bodyTextObj,
                        "tags": selections,
                        "name": name,
                        "headers": headerObj,
                        "duration": duration,
                        "delayed": parseFloat(delayed)
                    }
                ],
                "StoredProcedureJobs": []
            };

            executeApiJobPostRequest(jobType, body, function () {
                addSuccessAlert(document.getElementById("AddHttpJob"), "HTTP Job added");

                clearHttpJob(false);
            });
        });
    } catch (e) {
        addFailedAlert(document.getElementById("AddHttpJob"), `Something has gone wrong while adding a new HTTP Job. Exception: ${e}`);
    }
};

function clearHttpJob(removeAlertsTo = true) {
    clearList("httpTags");

    if (removeAlertsTo) {
        removeAlerts();
    }

    document.getElementById("httpJobEndpoint").value = "";
    document.getElementById("httpJobBody").value = "";
    document.getElementById("httpJobName").value = "";
    document.getElementById("httpJobDuration").value = "";
    document.getElementById("httpJobDelayed").value = "";
};

function addSPJob() {

    try {

        let jobTypeSelection = document.getElementById("spjobType");
        let jobType = jobTypeSelection.options[jobTypeSelection.selectedIndex].value;
        let spName = document.getElementById("storedProcedureName").value;

        var paramObj = {};
        let parameterContainer = document.getElementById("spParameters");
        for (var i = 0; i < parameterContainer.childElementCount; i++) {
            let parameterKey = parameterContainer.children[i].getElementsByTagName('input').key.value
            let parameterValue = parameterContainer.children[i].getElementsByTagName('input').value.value
            paramObj[parameterKey] = parameterValue;
        };

        let name = document.getElementById("storedProcedureJobName").value;
        let duration = document.getElementById("spJobDuration").value;
        let delayed = document.getElementById("spJobDelayed").value;

        if (delayed === "" || delayed === null || delayed === undefined || (!isNaN(delayed) && delayed.toString().indexOf('.') != -1)) {
            delayed = '0.0';
        }

        getDropdownValues("spParameters-tags", function (selections) {

            let body = {
                "HttpJobs": [],
                "StoredProcedureJobs": [
                    {
                        "storedProcedureName": spName,
                        "tags": selections,
                        "parameters": paramObj,
                        "name": name,
                        "duration": duration,
                        "delayed": delayed
                    }
                ]
            };

            executeApiJobPostRequest(jobType, body, function () {
                addSuccessAlert(document.getElementById("AddStoredProcedureJob"), "Stored Procedure Job added");

                clearSpJob(false);
            });
        });
    } catch (e) {
        addFailedAlert(document.getElementById("AddStoredProcedureJob"), `Something has gone wrong while adding a new Stored Procedure Job. Exception: ${e}`);
    }
};

function clearSpJob(removeAlertsTo = true) {
    clearList("spParameters");
    clearList("spTags");

    if (removeAlertsTo) {
        removeAlerts();
    }

    document.getElementById("storedProcedureName").value = "";
    document.getElementById("storedProcedureJobName").value = "";
    document.getElementById("spJobDuration").value = "";
    document.getElementById("spJobDelayed").value = "";
};

function clearList(elementName) {
    let parameterContainer = document.getElementById(elementName);
    for (var i = parameterContainer.childElementCount - 1; i >= 0; i--) {
        var paramrow = parameterContainer.children[i];
        parameterContainer.removeChild(paramrow);
    }
}

function executeApiJobPostRequest(executionType, body, _callback) {
    $.ajax({
        url: `/api/v1/job/${executionType}`,
        type: 'post',
        data: JSON.stringify(body),
        headers: {
            'Content-Type': 'application/json-patch+json'
        },
        dataType: 'json',
        statusCode: {
            200: function (response) {
                console.log(response);
                _callback();
            }
        }
    });
};

function executeApiTagGetAllRequest(_callback) {
    $.ajax({
        url: `/api/v1/tag/all`,
        type: 'get',
        headers: {
            'accept': 'application/json'
        },
        dataType: 'json',
        statusCode: {
            200: function (response) {
                console.log(response);
                _callback(response);
            }
        }
    });
};

function removeThisRow(element) {
    let row = element.parentNode.parentNode;
    let container = element.parentNode.parentNode.parentNode;
    container.removeChild(row);
};

function addFailedAlert(button, text) {
    var alert = `<div class='alert alert-danger' id="alertRow" role='alert'>${text}</div>`;
    AddAlert(button, alert);
};

function addSuccessAlert(button, text) {
    var alert = `<div class='alert alert-success' id="alertRow" role='alert'>${text}</div>`;
    AddAlert(button, alert);
};

function AddAlert(button, alert) {
    removeAlerts();

    var parent = button.parentNode;
    var div = document.createElement('div');
    div.classList.add("row");
    div.setAttribute("style", "padding-top:10px;");
    div.innerHTML = alert.trim();

    insertAfter(div, parent);
}

function insertAfter(newNode, referenceNode) {
    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling);
};

function removeAlerts() {
    var alertRowElement = document.getElementById("alertRow");
    while (alertRowElement !== null) {
        alertRowElement.remove();
        alertRowElement = document.getElementById("alertRow");
    }
};

$(document).ready(function () {
    $("#httpJobType").change(function () {
        if ($(this).val() == "recurring") {
            $("#recurring").show();
        }
        else {
            $("#recurring").hide();
        }

        if ($(this).val() == "delayed") {
            $("#delayed").show();
        }
        else {
            $("#delayed").hide();
        }
    });

    $("#spjobType").change(function () {
        if ($(this).val() == "recurring") {
            $("#recurringSp").show();
        }
        else {
            $("#recurringSp").hide();
        }

        if ($(this).val() == "delayed") {
            $("#delayedSp").show();
        }
        else {
            $("#delayedSp").hide();
        }
    });

    $("#addSpParameter").add("#addHttpHeaders").click(function (element) {
        let id = element.target.nextElementSibling.id;
        $(`#${id}`).append("<div class='row'><div class='col-md-2'><label>Key:</label></div><div class='col-md-3'><input class='form-control' id='key' type='text' /></div><div class='col-md-2'><label>Value:</label></div><div class='col-md-3'><input class='form-control' id='value' type='text' /></div><div class='col-md-2'><button class='btn' onclick='removeThisRow(this)'>-</button></div><br /></div>")
    });

    $("#addHttpTags").add("#addSpTags").click(function (element) {
        let id = element.target.nextElementSibling.id;

        executeApiTagGetAllRequest(function (tags) {
            generateDropdown(id, tags, function (selectElement) {
                $(`#${id}`).append(`<div class='row'><div class='col-md-2'><label>Tag:</label></div><div class='col-md-3'>${selectElement}</div><div class='col-md-2'><button class='btn' onclick='removeThisRow(this)'>-</button></div><br /></div>`)
            });
        });
    });
});


function generateDropdown(id, options, _callback) {

    var selectElement = [];

    selectElement.push(`<select class="form-control ${id}-tags">`);

    getDropdownValues(`${id}-tags`, function (alreadySelected) {

        var leftOverOptions = options.filter(function (item) {
            return alreadySelected.includes(item.name) === false;
        });

        for (var i = 0; i < leftOverOptions.length; i++) {
            selectElement.push(`<option value="${leftOverOptions[i].name}">${leftOverOptions[i].name}</option>`);
        }

        selectElement.push(`</select>`);

        _callback(selectElement.toString());
    });
};

function getDropdownValues(classId, _callback) {
    let tagSelectElements = document.getElementsByClassName(classId);
    var selections = [];

    for (var i = 0; i < tagSelectElements.length; i++) {
        let value = tagSelectElements[i].value;

        if (value !== "") {
            selections.push(tagSelectElements[i].value);
        }
    }

    _callback(selections);
}