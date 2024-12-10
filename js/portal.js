$(document).ready(function () {
	$('body').addClass('skin-blue sidebar-mini');
	$('body').addClass(localStorage.getItem('sidebar-collapse'));
	$('.select2').select2()
});

$('body').on('expanded.pushMenu collapsed.pushMenu', function (e) {
	var collape = localStorage.getItem('sidebar-collapse');
	if (collape === 'sidebar-collapse')
		localStorage.setItem('sidebar-collapse', '');
	else
		localStorage.setItem('sidebar-collapse', 'sidebar-collapse');
});

function filterMenu() {
	var datafilter = $('.sidebar-form input').val();
	$.each($('.sidebar-menu li'), function(i, com) {
		var name = $(com).find('.menu-name').html();
		$(com).removeClass('filter-found');
		if (name != undefined
				&& name.toLowerCase().indexOf(datafilter.toLowerCase()) < 0) {
            $(com).hide();
            //console.log(name);
		} else {
			$(com).show();
			var p = $(com).parent().parent('li');
			if (p !== undefined) {
				p.show();
				if (datafilter !== '') {
					$(com).addClass('filter-found');
					if (!p.hasClass('active'))
						p.addClass('active menu-open open-filter');
				} else {
					if (p.hasClass('open-filter')) {
						p.removeClass('active menu-open open-filter');
					}
				}
            }
            //console.log(p);
		}
	});
	if (!$('.enter')) {
		activeEnterMenus(0);
	}
}

function clickFilterMenu() {
	var menu = $('.enter');
	window.location = menu.attr("href");
}

function clearMenuFilter() {
	$('.sidebar-form input').val('');
	$('.enter').removeClass('enter');
	filterMenu();
}

function arrowEnterMenu(event) {
	switch (event.keyCode) {
	case 40:
		arrowDownEnterMenu();
		break;
	case 38:
		arrowUpEnterMenu();
		break;
	case 13:
		clickFilterMenu()
		break;
	}
}

function arrowDownEnterMenu() {
	var i = $('.filter-found:not(.header) > a').index($('.enter'));
	var count = $('.filter-found:not(.header) > a').length;
	if (i >= count - 1)
		i = -1;
	activeEnterMenus(i + 1);
}

function arrowUpEnterMenu() {
	var i = $('.filter-found:not(.header) > a').index($('.enter'));
	var count = $('.filter-found:not(.header) > a').length;
	if (i <= 0)
		i = count;
	activeEnterMenus(i - 1);
}

function activeEnterMenus(i) {
	$('.enter').removeClass('enter');
	var menu = $('.filter-found:not(.header) > a')[i];
	$(menu).addClass('enter');
}

function activeEnterMenu() {
	if (!$('.enter')) {
		var menu = $('.filter-found:not(.header) > a')[0];
		$(menu).addClass('enter');
	}
}