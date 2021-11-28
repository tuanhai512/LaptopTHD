var properties = [
	'id',
	'name',
	'cate',
	'oriprice',
	'price',
	'quantity',
	'phone',
	'datetime',
	'email',
];

$.each(properties, function (i, val) {

	var orderClass = '';

	$("#" + val).click(function (e) {
		e.preventDefault();
		$('.filter__link.filter__link--active').not(this).removeClass('filter__link--active');
		$(this).toggleClass('filter__link--active');
		$('.filter__link').removeClass('△ ▽');

		if (orderClass == '▽' || orderClass == '') {
			$(this).addClass('△ ');
			orderClass = '△ ';
		} else {
			$(this).addClass('▽');
			orderClass = '▽';
		}

		var parent = $(this).closest('.header__item');
		var index = $(".header__item").index(parent);
		var $table = $('.table-content');
		var rows = $table.find('.table-row').get();
		var isSelected = $(this).hasClass('filter__link--active');
		var isNumber = $(this).hasClass('filter__link--number');

		rows.sort(function (a, b) {

			var x = $(a).find('.table-data').eq(index).text();
			var y = $(b).find('.table-data').eq(index).text();

			if (isNumber == true) {

				if (isSelected) {
					return x - y;
				} else {
					return y - x;
				}

			} else {

				if (isSelected) {
					if (x < y) return -1;
					if (x > y) return 1;
					return 0;
				} else {
					if (x > y) return -1;
					if (x < y) return 1;
					return 0;
				}
			}
		});

		$.each(rows, function (index, row) {
			$table.append(row);
		});

		return false;
	});

});