// JavaScript source code
var devmoba = devmoba || {};
(function ($) {
    if (!$) {
        throw "devmoba library requires the jquery library included to the page!";
    }

    devmoba.datatables = devmoba.datatables || {
        tableSelector: '',
        columnSettings: [],
        enableRangeFilter: () => {
            $.fn.dataTable.ext.search.push(devmoba.datatables.searchHelper.rangeFilter);
        },
        enableIndividualColumnSearch: (tableSelector, columnSettings) => {
            devmoba.datatables.tableSelector = tableSelector;
            devmoba.datatables.columnSettings = columnSettings;

            let tableHead = $(tableSelector).children('thead');

            tableHead.children('tr').clone(true).appendTo(tableHead);
            tableHead.children('tr:eq(1)').children('th').each((col, element) => {
                let currentColSettings = columnSettings[col];

                if (currentColSettings.searchDisabled) {
                    $(element).html('');
                } else if (currentColSettings.enableRangeFilter) {
                    $(element).html(`<input type="text" placeholder="Min" class="search_rmin_${col} form-control" style="width: 45%; display: inline-block; padding: 3px 7px;" onkeyup="devmoba.datatables.searchHelper.onKeyupHandler(this)" onfocus="devmoba.datatables.searchHelper.onfocusHandler(this)"/>-<input type="text" placeholder="Max" class="search_rmax_${col} form-control" style="width: 45%; display: inline-block; padding: 3px 7px;" onkeyup="devmoba.datatables.searchHelper.onKeyupHandler(this)" onfocus="devmoba.datatables.searchHelper.onfocusHandler(this)"/>`)
                } else if (currentColSettings.options) {
                    let dropdownHtml = `<select class="form-control search_c_${col}" style="padding: 3px 7px;" onchange="devmoba.datatables.searchHelper.onKeyupHandler(this); devmoba.datatables.searchHelper.onfocusHandler(this);">`;
                    dropdownHtml += '<option value="">--</option>'
                    currentColSettings.options.forEach(s => {
                        dropdownHtml += `<option value="${s.value}">${s.text}</option>`;
                    });
                    dropdownHtml += '</select>';
                    $(element).html(dropdownHtml);
                } else {
                    $(element).html(`<input type="text" placeholder="Search" class="search_c_${col} form-control" style="padding: 3px 7px;" onkeyup="devmoba.datatables.searchHelper.onKeyupHandler(this)" onfocus="devmoba.datatables.searchHelper.onfocusHandler(this)"/>`);
                }
            });

            if (columnSettings.some(cs => cs.enableRangeFilter)) {
                devmoba.datatables.enableRangeFilter();
            }
        },
        searchHelper: {
            keyupThrottle: 500,
            searchInputRegex: new RegExp('search_(c|rmin|rmax)_(\\d+)'),
            lastKeyup: Date.now(),
            rangeSearchConditions: [],
            timeoutIdentifier: null,
            executeFilter: (el) => {
                let table = $(devmoba.datatables.tableSelector).DataTable();
                let matched = devmoba.datatables.searchHelper.searchInputRegex.exec(el.className);
                if (!matched)
                    return;
                let searchType = matched[1];
                let col = Number(matched[2]);

                if (searchType === 'c' && table.column(col).search() !== el.value) {
                    table.column(col).search(el.value).draw();
                } else {
                    var rangeCondition = {
                        col: col
                    };
                    if (searchType === 'rmin')
                        rangeCondition.min = el.value.trim() ? Number(el.value) : NaN;
                    else if (searchType === 'rmax')
                        rangeCondition.max = el.value.trim() ? Number(el.value) : NaN;

                    let condId = devmoba.datatables.searchHelper.rangeSearchConditions.findIndex(c => c.col === col);
                    if (condId > -1) {
                        if (rangeCondition.hasOwnProperty('min'))
                            devmoba.datatables.searchHelper.rangeSearchConditions[condId].min = rangeCondition.min;
                        if (rangeCondition.hasOwnProperty('max'))
                            devmoba.datatables.searchHelper.rangeSearchConditions[condId].max = rangeCondition.max;
                        if (!devmoba.datatables.searchHelper.rangeSearchConditions[condId].min && !devmoba.datatables.searchHelper.rangeSearchConditions[condId].max)
                            devmoba.datatables.searchHelper.rangeSearchConditions.splice(condId, 1);
                    } else {
                        devmoba.datatables.searchHelper.rangeSearchConditions.push(rangeCondition);
                    }
                    table.draw();
                }
            },
            onfocusHandler: el => {
                devmoba.datatables.searchHelper.lastKeyup = Date.now();
            },
            onKeyupHandler: (el) => {
                let table = $(devmoba.datatables.tableSelector).DataTable();
                let oldLastKeyup = devmoba.datatables.searchHelper.lastKeyup;
                devmoba.datatables.searchHelper.lastKeyup = Date.now();
                if (devmoba.datatables.searchHelper.lastKeyup - oldLastKeyup <= devmoba.datatables.searchHelper.lastKeyup) {
                    clearTimeout(devmoba.datatables.searchHelper.timeoutIdentifier);
                }
                devmoba.datatables.searchHelper.timeoutIdentifier = setTimeout(() => {
                    devmoba.datatables.searchHelper.executeFilter(el, table);
                }, devmoba.datatables.searchHelper.keyupThrottle);
            },
            rangeFilter: (settings, data, dataIndex) => {
                let rs = true;
                devmoba.datatables.searchHelper.rangeSearchConditions.forEach((cond) => {
                    let colData = parseFloat(data[cond.col]);
                    let min = cond.min;
                    let max = cond.max;

                    rs = rs && ((isNaN(min) && isNaN(max))
                        || (isNaN(min) && colData <= max)
                        || (min <= colData && isNaN(max))
                        || (min <= colData && colData <= max));
                });
                return rs;
            },
            getSearchConditions: () => {
                let table = $(devmoba.datatables.tableSelector).DataTable();
                let rs = {};
                if (table.page.info() && table.page.info().serverSide === true) {
                    let rangeSearchConditions = devmoba.datatables.searchHelper.rangeSearchConditions;

                    devmoba.datatables.columnSettings.forEach((colSetting, colIndex) => {
                        if (colSetting.searchDisabled)
                            return;
                        let colName = colSetting.name;
                        let rangeSearchCond = rangeSearchConditions.find(cond => cond.col === colIndex);

                        if (rangeSearchCond != null) {
                            rs[`${colName}Min`] = isNaN(rangeSearchCond.min) ? null : rangeSearchCond.min;
                            rs[`${colName}Max`] = isNaN(rangeSearchCond.max) ? null : rangeSearchCond.max;
                        } else {
                            rs[colName] = table.column(colIndex).search();
                        }
                    });
                }
                return rs;
            }
        },
        fixDomConfiguration: (config) => {
            config.dom = '<"col-auto"l>rt<"row data_Table_footer"<"col-auto"i><"col"p>>';
            if (!config.scrollY) {
                config.scrollY = "57vh";
            }
            return config;
        }
    };
})(jQuery);