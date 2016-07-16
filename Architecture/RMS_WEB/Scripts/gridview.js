(function ($) {
    $.fn.addGridView = function (dataTable, jsonConfig, cssID, addNewCallBack) {
        try {
            /*public variables and methods*/
            var oGrid = this;
            oGrid.pageSize = 8;
            oGrid.pageIndex = 0;
            oGrid.dataTable = dataTable;
            oGrid.addButtonText = "Add New";
            oGrid.objName = "";
            oGrid.applyEffects = false;

            oGrid.displayPage = function () {
                try {
                    resetError();
                    if (dataTable[0] == null) {
                        displayError("no data available");
                        gridTableBody.empty();
                        return;
                    }

                    var recCount = oGrid.dataTable.length;
                    var pageCount = Math.ceil(recCount / oGrid.pageSize);

                    if (oGrid.pageIndex >= pageCount) {
                        oGrid.pageIndex--;
                    }

                    var intOffset = oGrid.pageSize * oGrid.pageIndex;

                    if (pageCount > 1) {
                        addNavigationLinks();
                    }
                    else {
                        pagingControl.empty();
                    }

                    if (arFieldIX.length == 0 && jsonConfig !== null) {
                        populateLookupIndex();
                    }

                    gridTableBody.empty();

                    for (i = 0; i < oGrid.pageSize; i++) {
                        if ((intOffset + i) < recCount) {
                            var tableRow = $(gridTableBody).addNewElement("tr", rootID + "_Row_" + eval(i + intOffset), cssID + "Row");
                            addColumns(tableRow, intOffset + i);
                        }
                    }


                    if (oGrid.applyEffects) { oGrid.effect("slide", { easing: 'easeInCubic' }, 200); }
                }
                catch (ex) {
                    displayError("displayPage error: " + ex);
                }
            }

            this.onPagingClick = function (pageIX) {
                oGrid.pageIndex = pageIX;
                oGrid.displayPage();
                return false;
            }

            /*private variables and methods*/
            var gridTable;
            var gridTableBody;
            var gridError;
            var pagingControl;
            var arFieldIX = [];
            var isGridTableInit = false;
            var rootID = this[0].id;

            function Init() {
                try {
                    gridError = $(oGrid).addNewElement("div", rootID + "Error", cssID + "Error");
                    gridTable = $(oGrid).addNewElement("table", rootID + "Table", cssID + "Table");
                    var tableFooter = $(gridTable).addNewElement("tfoot", rootID + "Footer", cssID + "Footer");
                    var tableFooterRow = $(tableFooter).addNewElement("tr", rootID + "FooterRow", cssID + "FooterRow");

                    var tableFooterCell = $(tableFooterRow).addNewElement("td", rootID + "FooterCell", cssID + "FooterCell").attr("colspan", getNavigationColspan());
                    pagingControl = $(tableFooterCell).addNewElement("div", rootID + "Paging", cssID + "Paging");

                    if (addNewCallBack != null) {
                        var addnewButtonCell = $(tableFooterRow).addNewElement("td", rootID + "FooterCell2", cssID + "FooterCell");
                        var addNewButton = $(addnewButtonCell).addNewElement("input", rootID + "_AddNewButton", cssID + "AddNew").attr("type", "button").attr("value", oGrid.addButtonText);
                        addNewButton.click(function (e) {
                            e.preventDefault();
                            addNewCallBack(oGrid);
                        });
                    }
                    initGridtable();
                }
                catch (ex) {
                    alert("Init error: " + ex);
                }
            }

            function getNavigationColspan() {
                try {
                    var colSpan = 10;
                    if (jsonConfig != null) { colSpan = jsonConfig.length - 1; }
                    else if (oGrid.dataTable !== null && oGrid.dataTable.length>0) {
                        var dataRow = oGrid.dataTable[0];
                        var colSpan = Object.keys(dataRow).length - 1;
                    }

                    if (colSpan < 1) { colSpan = 1; }
                    return colSpan;
                }
                catch (ex) {
                    alert("getNavigationColspan"+ ex);
                }
            }

            function addNavigationLink(strCaption, linkIndex) {
                try {
                    var oLink = $(pagingControl).addNewElement("a", rootID + "NavigationLink_" + linkIndex, cssID + "NavigationLink").attr("href", "").text(strCaption);

                    if (linkIndex == oGrid.pageIndex) {
                        oLink.removeClass(cssID + "NavigationLink").addClass(cssID + "NavigationCurrentPage");
                    }

                    oLink.click(function (e) {
                        e.preventDefault();
                        if (linkIndex !== this.pageIndex) {
                            oGrid.onPagingClick(linkIndex);
                        }
                    });
                }
                catch (ex) {
                    displayError("addNavigationLink error: " + ex);
                }
            }

            function addNavigationLinks() {
                try {
                    pagingControl.empty();

                    var recCount = oGrid.dataTable.length;
                    var linkCount = 7;
                    var maxPage = Math.ceil(recCount / oGrid.pageSize) - 1;

                    addNavigationLink(" 1 ", 0);
                    if (oGrid.pageIndex > Math.ceil(linkCount / 2) && maxPage > (linkCount + 1)) {
                        pagingControl.append(" ... ");
                    }

                    var ixFrom = oGrid.pageIndex - Math.floor(linkCount / 2);
                    if (ixFrom > (maxPage - linkCount)) { ixFrom = maxPage - linkCount; }
                    if (ixFrom < 1) { ixFrom = 1; }

                    var ixTo = oGrid.pageIndex + (Math.floor(linkCount / 2));
                    if (ixTo < linkCount) { ixTo = linkCount; }
                    if (ixTo > (maxPage - 1)) { ixTo = maxPage - 1; }

                    for (i = ixFrom; i <= ixTo; i++) {
                        addNavigationLink(" " + eval(i + 1) + " ", i);
                    }

                    if (oGrid.pageIndex < (maxPage - Math.ceil(linkCount / 2)) && maxPage > (linkCount + 1)) {
                        pagingControl.append(" ... ");
                    }

                    addNavigationLink(" " + eval(maxPage + 1) + " ", maxPage);
                }
                catch (ex) {
                    displayError("addNavigationLinks error: " + ex);
                }
            }

            function addColumns(tableRow, i) {
                try {
                    var dataRow = oGrid.dataTable[i];
                    
                    if (arFieldIX.length > 0) {
                        for (j = 0; j < arFieldIX.length; j++) {
                            if (typeof jsonConfig[j].StaticText != "undefined") {
                                addCell(tableRow, j, i, jsonConfig[j].StaticText);
                            }
                            else if (arFieldIX[j] > -1) {
                                var fieldValue = dataRow[Object.keys(dataRow)[arFieldIX[j]]];
                                if (typeof jsonConfig[j].LookUp != "undefined") {
                                    try {
                                        var arLookup = dataArrays[jsonConfig[j].LookUp];
                                        if (typeof arLookup != "undefined") { fieldValue = arLookup[fieldValue]; }
                                    }
                                    catch (ex1) {
                                    }
                                }
                                addCell(tableRow, j, i, fieldValue);
                            }
                            else {
                                addCell(tableRow, j, i, "");
                            }
                        }
                    }
                    else {
                        var colCount = Object.keys(dataRow).length
                        for (j = 0; j < colCount; j++) {
                            addCell(tableRow, i, j, dataRow[Object.keys(dataRow)[j]])
                        }
                    }
                }
                catch (ex) {
                    displayError("addColumns error: " + ex);
                }
            }

            function addCell(tableRow, j, i, strCellData) {
                var rowCell = $(tableRow).addNewElement("td", rootID + "RowCell_" + j + "_" + i, cssID + "Cell");
                try {
                    if (strCellData == null) { strCellData = ""; }                  //No data at all, empty cell

                    if (typeof strCellData !== "undefined") {
                        if (strCellData.toString().indexOf("\/Date") > -1) {        //Data is a Date, format it as a Date
                            var dtDate = new Date(strCellData.match(/\d+/)[0] * 1);
                            strCellData = $().formatDate(dtDate);
                        }
                    }

                    if ((jsonConfig !== null) && (typeof jsonConfig[j].HyperLinkField !== "undefined")) {
                        var hyperLink = $(rowCell).addNewElement("a", rootID + "_CellLink_" + eval(i), cssID + "CellLink").attr("href", "").text(strCellData);

                        var hyperLinkHref = jsonConfig[j].HyperLinkField
                        var RowIX = i;
                        hyperLink.click(function (e) {
                            e.preventDefault();
                            hyperLinkHref(RowIX, oGrid);
                        });
                    }
                    else {
                        rowCell.text(strCellData);
                    }

                    //set the cell width
                    if ((jsonConfig !== null) && (typeof jsonConfig[j].Width !== "undefined")) {
                        rowCell.width(jsonConfig[j].Width);
                    }
                    else {
                        rowCell.width(100);
                    }
                }
                catch (ex) {
                    displayError("addCell error: " + ex + " " + strCellData + "--");
                }
            }

            function initGridtable() {
                try {
                    resetError();

                    gridTableBody = $(gridTable).addNewElement("tbody", rootID + "tbody", cssID + "tbody");
                    var gridTableHeader = $(gridTable).addNewElement("thead", rootID + "thead", cssID + "thead");
                    var headerRow = $(gridTableHeader).addNewElement("tr", rootID + "HeaderRow", cssID + "HeaderRow");

                    if (jsonConfig != null) {
                        for (i = 0; i < jsonConfig.length; i++) {
                            $(headerRow).addNewElement("td", rootID + "HeaderCell_" + i, cssID + "HeaderCell").text(jsonConfig[i].HeaderText).width(jsonConfig[i].Width);
                        }
                    } else {
                        if (oGrid.dataTable[0] == null) {
                            displayError("no data available");
                            gridTable.width(250);
                        }
                        else {
                            var dataRow = oGrid.dataTable[0];
                            for (i = 0; i < Object.keys(dataRow).length; i++) {
                                $(headerRow).addNewElement("td", rootID + "HeaderCell_" + i, cssID + "HeaderCell").text(Object.keys(dataRow)[i]).width(100);
                            }
                        }
                    }
                }
                catch (ex) {
                    displayError("initGridtable error: " + ex);
                }
            }

            function populateLookupIndex() {
                var dataRow = oGrid.dataTable[0];
                arFieldIX = [];
                for (i = 0; i < jsonConfig.length; i++) {
                    var DataField = jsonConfig[i].DataField;

                    var k = -1;
                    do { k++ }
                    while (k < Object.keys(dataRow).length && DataField != Object.keys(dataRow)[k])

                    if (k < Object.keys(dataRow).length) {
                        arFieldIX.push(k);
                    }
                    else {
                        arFieldIX.push(-1);
                    }
                }
            }

            function displayError(strError) {
                gridError.text(gridError.text() + " " + strError);
                gridError.show();
                setTimeout(function () { resetError() }, 15000);
            }

            function resetError() {
                gridError.text("");
                gridError.hide();
            }

            Init();
            return this;
        }
        catch (ex) {
            alert(ex);
        }
    };
}(jQuery));

(function ($) {
    $.fn.addNewElement = function (strType, strID, strClassName) {
        try {
            return $(document.createElement(strType)).appendTo(this).attr("id", strID).addClass(strClassName);
        }
        catch (ex) {
            alert(ex);
        }
    };
}(jQuery));

(function ($) {
    /*
    HH - The hour, using a 24-hour clock from 00 to 23.
    H - The hour, using a 24-hour clock from 0 to 23.
    hh - The hour, using a 12-hour clock from 01 to 12.
    h - The hour, using a 12-hour clock from 1 to 12.
    mm -The minute, from 00 through 59.
    mm -The minute, from 0 through 59.
    ss - The second, from 00 through 59.
    ss - The second, from 0 through 59.
    "MMMM" - The full name of the month.
    "MMM" - The abbreviated name of the month. 
    "MM" - The month, from 01 through 12.
    "dddd" - The full name of the day of the week.
    "ddd" - The abbreviated name of the day of the week.
    "dd" - The day of the month, from 01 through 31.
    "yyyy" - The year as a four-digit number.
    */
    $.fn.formatDate = function (dtDate,strFormat) {
        try {
            var fstr = "MMMM dd yyyy, hh:mm:ss tt";
            if (strFormat !== "undefined" && strFormat!=null) {
                fstr = strFormat;
            }

            var arMonths = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var arMonthsShort = ["Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec"];
            var arDayOfWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
            var arDayOfWeekShort = ["Mon", "Tue", "Wed", "Thur", "Fri", "Sat", "Sun"];
            var strResponse = fstr.replace("HH", addLeadingZero(dtDate.getHours())).replace("H", dtDate.getHours()).
                replace("hh", getTwelveHourString(true)).replace("h", getTwelveHourString(false)).replace("tt", getAMPM()).
                replace("mm", addLeadingZero(dtDate.getMinutes())).replace("m", dtDate.getMinutes()).
                replace("ss", addLeadingZero(dtDate.getSeconds())).replace("s", addLeadingZero(dtDate.getSeconds())).
                replace("MMMM", arMonths[dtDate.getMonth()]).replace("MMM", arMonthsShort[dtDate.getMonth()]).replace("MM",addLeadingZero(dtDate.getMonth()+1)).
                replace("dddd", arDayOfWeek[dtDate.getDay()]).replace("ddd", arDayOfWeekShort[dtDate.getDay()]).replace("dd", addLeadingZero(dtDate.getDate())).
                replace("yyyy", dtDate.getFullYear());

            return strResponse;
        }
        catch (ex) {
            alert(ex);
        }

        function getAMPM() {
            var intHours = dtDate.getHours();
            if (intHours > 11) {
                return "PM";
            }
            else {
                return "AM";
            }
        }

        function getTwelveHourString(addZero) {
            var intHours = dtDate.getHours();

            if (intHours > 12) {
                intHours -= 12;
            }

            if (addZero) {
                return addLeadingZero(intHours);
            }
            else {
                return intHours;
            }
        }

        function addLeadingZero(intNumber) {
            if (intNumber < 10) {
                return "0" + intNumber;
            }
            else {
                return intNumber + "";
            }
        }
    };
}(jQuery));

(function ($) {
    $.fn.setCountryProvince = function (countryElementID, provinceElementID, countryCode, provinceCode) {
        var $self = this;
        var elementProvinces;
        var elementCountries;
        var strCountry;
        var strProvince;
        var defaultCountry = "CA";

        $self.doRefresh = function () {
            try {
                var strCountryNew = elementCountries.value;
                switch (strCountryNew) {
                    case "CA":
                        elementProvinces.disabled = false;
                        $(elementProvinces).populateSelect(dataArrays.ProvincesCA);
                        break;
                    case "US":
                        elementProvinces.disabled = false;
                        $(elementProvinces).populateSelect(dataArrays.StatesUS);
                        break;
                    case "AU":
                        elementProvinces.disabled = false;
                        $(elementProvinces).populateSelect(dataArrays.ProvincesAU);
                        break;
                    default:
                        elementProvinces.options.length = 0;
                        elementProvinces.disabled = true;
                        break;
                }
                if (elementCountries.value == strCountry) { elementProvinces.value = strProvince; }
            }
            catch (ex) {
                alert(ex);
            }
        }

        function Init() {
            try {
                elementProvinces = (provinceElementID == null) ? null : document.getElementById(provinceElementID);
                strProvince = provinceCode;

                elementCountries = (countryElementID == null) ? null : document.getElementById(countryElementID); 
                strCountry = countryCode;

                if (elementCountries == null) {
                    return;
                }

                if (strCountry == null) { strCountry = defaultCountry; }

                $(elementCountries).populateSelect(dataArrays.Countries);
                elementCountries.value = strCountry;

                $self.doRefresh();
                elementProvinces.value = strProvince;

                elementCountries.onchange = function () {
                    $self.doRefresh();
                }
            }
            catch (ex) {
                alert(ex);
            }
        }

        Init();
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.populateSelect = function (jsonDataParam) {
        var self = this;
        var jsonData;
        function Init() {
            try {
                for (i = 0; i < self.length; i++) {
                    if (jsonDataParam !== null) {
                        jsonData = jsonDataParam;
                    }
                    else {
                        jsonData = dataArrays[$(self[i]).attr("data-lookup")];
                    }

                    if (typeof jsonData !== "undefined") {
                        self[i].disabled = false;
                        self[i].options.length = 0;
                        for (j = 0; j < Object.keys(jsonData).length; j++) {
                            var optionName = Object.keys(jsonData)[j];
                            self[i].options.add(new Option(jsonData[optionName], optionName));
                        }
                    }
                }
            }
            catch (ex) {
                alert(ex);
            }
        }

        Init();
        return this;
    }
}(jQuery));

var dataArrays = {
    "Countries": {
        "CA": "Canada", "US": "Unites States", "AF": "Afghanistan", "AL": "Albania", "DZ": "Algeria",
        "AS": "American Samoa", "AD": "Andorra", "AO": "Angola", "AR": "Argentina", "AM": "Armenia",
        "AU": "Australia", "AT": "Austria", "AZ": "Azerbaijan", "BS": "Bahamas", "BH": "Bahrain",
        "BD": "Bangladesh", "BB": "Barbados", "BY": "Belarus", "BE": "Belgium", "BM": "Bermuda",
        "BA": "Bosnia and Herzegovina", "BR": "Brazil", "BG": "Bulgaria", "KY": "Cayman Islands", "CL": "Chile",
        "CN": "China", "CO": "Colombia", "CG": "Congo", "CR": "Costa Rica", "HR": "Croatia",
        "CU": "Cuba", "CY": "Cyprus", "CZ": "Czech Republic", "DK": "Denmark", "EC": "Ecuador",
        "EG": "Egypt", "SV": "El Salvador", "EE": "Estonia", "ET": "Ethiopia", "FI": "Finland",
        "FR": "France", "GE": "Georgia", "DE": "Germany", "GR": "Greece", "GD": "Grenada",
        "GP": "Guadeloupe", "GU": "Guam", "GT": "Guatemala", "GY": "Guyana", "HT": "Haiti",
        "HN": "Honduras", "HU": "Hungary", "IS": "Iceland", "IN": "India", "ID": "Indonesia",
        "IQ": "Iraq", "IE": "Ireland", "IL": "Israel", "IT": "Italy", "JM": "Jamaica",
        "JP": "Japan", "JO": "Jordan", "KZ": "Kazakhstan", "KE": "Kenya", "KW": "Kuwait", "LV": "Latvia",
        "LB": "Lebanon", "LI": "Liechtenstein", "LT": "Lithuania", "LU": "Luxembourg", "MG": "Madagascar", "MY": "Malaysia",
        "MT": "Malta", "MX": "Mexico", "MC": "Monaco", "MN": "Mongolia", "ME": "Montenegro", "MA": "Morocco",
        "NL": "Netherlands", "NZ": "New Zealand", "NI": "Nicaragua", "NG": "Nigeria", "NO": "Norway", "OM": "Oman",
        "PK": "Pakistan", "PA": "Panama", "PY": "Paraguay", "PE": "Peru", "PH": "Philippines", "PL": "Poland",
        "PT": "Portugal", "PR": "Puerto Rico", "QA": "Qatar", "RO": "Romania", "RW": "Rwanda", "SM": "San Marino",
        "SA": "Saudi Arabia", "SN": "Senegal", "RS": "Serbia", "SG": "Singapore", "SK": "Slovakia", "SI": "Slovenia",
        "ZA": "South Africa", "ES": "Spain", "LK": "Sri Lanka", "SD": "Sudan", "SE": "Sweden", "CH": "Switzerland",
        "TH": "Thailand", "TN": "Tunisia", "TR": "Turkey", "TM": "Turkmenistan", "UG": "Uganda", "UA": "Ukraine",
        "AE": "United Arab Emirates", "GB": "United Kingdom", "UY": "Uruguay", "UZ": "Uzbekistan", "YE": "Yemen",
        "ZM": "Zambia", "ZW": "Zimbabwe", "HK": "Hong Kong", "IR": "Iran", "KR": "Korea", "LY": "Libyan", "RU": "Russia",
        "SY": "Syrian Arab Republic", "TW": "Taiwan", "VN": "Viet Nam"
    },
    "ProvincesCA": {
        "AB": "Alberta", "BC": "British Columbia", "MB": "Manitoba", "NB": "New Brunswick",
        "NL": "Newfoundland and Labrador", "NT": "Northwest Territories", "NS": "Nova Scotia", "NU": "Nunavut",
        "ON": "Ontario", "PE": "Prince Edward Island", "QC": "Quebec", "SK": "Saskatchewan", "YT": "Yukon"
    },
    "ProvincesAU": {
        "ACT": "Australian Capital Territory", "NSW": "New South Wales", "NT": "Northern Territory", "QLD": "Queensland",
        "SA": "South Australia", "TAS": "Tasmania", "VIC": "Victoria", "WA": "Western Australia"
    },
    "StatesUS": {
        "AL": "Alabama", "AK": "Alaska", "AZ": "Arizona", "AR": "Arkansas", "CA": "California",
        "CO": "Colorado", "CT": "Connecticut", "DE": "Delaware", "DC": "District of Columbia", "FL": "Florida",
        "GA": "Georgia", "HI": "Hawaii", "ID": "Idaho", "IL": "Illinois", "IN": "Indiana",
        "IA": "Iowa", "KS": "Kansas", "KY": "Kentucky", "LA": "Lousiana", "ME": "Maine",
        "MD": "Maryland", "MA": "Massachusetts", "MI": "Michigan", "MN": "Minnesota", "MS": "Mississippi",
        "MO": "Missouri", "MT": "Montana", "NE": "Nebraska", "NV": "Nevada", "NH": "New Hampshire",
        "NJ": "New Jersey", "NM": "New Mexico", "NY": "New York", "NC": "North Carolina", "ND": "North Dakota",
        "OH": "Ohio", "OK": "Oklahoma", "OR": "Oregon", "PA": "Pennsylvania", "RI": "Rhode Island",
        "SC": "South Carolina", "SD": "South Dakota", "TN": "Tennessee", "TX": "Texas", "UT": "Utah",
        "VT": "Vermont", "VA": "Virginia", "WA": "Washington", "WV": "West Virginia", "WI": "Wisconsin", "WY": "Wyoming"
    },
}

var statusCodes = { "0": "non-verified", "1": "free user", "2": "paying user", "3": "canceled", "4": "banned" }

dataArrays["statusCodes"] = statusCodes;
dataArrays["allProvinces"] = $.extend({}, dataArrays.ProvincesCA, dataArrays.ProvincesAU, dataArrays.StatesUS);


