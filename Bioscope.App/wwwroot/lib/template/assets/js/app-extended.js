var AppExtended = (function() {
  var _componentFloatingLabels = function() {
    // Variables
    var showClass = 'is-visible',
      animateClass = 'animate',
      labelWrapperClass = 'form-group-float',
      labelClass = 'form-group-float-label';

    // Setup
    $(
      'input:not(.token-input):not(.bootstrap-tagsinput > input), textarea, select'
    )
      .on('checkval change', function() {
        // Define label
        var label = $(this)
          .parents('.' + labelWrapperClass)
          .children('.' + labelClass);

        // Toggle label
        if (this.value !== '') {
          label.addClass(showClass);
        } else {
          label.removeClass(showClass).addClass(animateClass);
        }
      })
      .on('keyup', function() {
        $(this).trigger('checkval');
      })
      .trigger('checkval')
      .trigger('change');

    // Remove animation on page load
    $(window).on('load', function() {
      $('.' + labelWrapperClass)
        .find('.' + showClass)
        .removeClass(animateClass);
    });
  };

  var _componentPerfectScrollbar = function() {
    if (typeof PerfectScrollbar == 'undefined') {
      console.warn('Warning - perfect_scrollbar.min.js is not loaded.');
      return;
    }

    // Initialize
    var ps = new PerfectScrollbar('.sidebar-fixed .sidebar-content', {
      wheelSpeed: 2,
      wheelPropagation: true
    });
  };

  var _componentSelect2 = function() {
    if (!$().select2) {
      console.warn('Warning - select2.min.js is not loaded.');
      return;
    }

    // Select with search
    $('.select-search').select2();
    $('.select-search').on('change', function() {
      $('form').valid();
    });
  };

  return {
    init: function() {
      _componentFloatingLabels();
      _componentPerfectScrollbar();
      _componentSelect2();
    }
  };
})();

var SweetAlert = (function() {
  swal.setDefaults({
    buttonsStyling: false,
    confirmButtonClass: 'btn btn-primary',
    cancelButtonClass: 'btn btn-light',
    width: '400px'
  });

  // alert types warning, error, success, info, and question
  var _alertWarning = function(title, text) {
    swal({
      type: 'warning',
      title: `${title}`,
      html: `${text}`,
      showConfirmButton: false
    });
  };

  var _alertError = function(title, text) {
    swal({
      type: 'error',
      title: `${title}`,
      html: `${text}`,
      showConfirmButton: false
    });
  };

  var _alertSuccess = function(title, text) {
    swal({
      type: 'success',
      title: `${title}`,
      html: `${text}`,
      showConfirmButton: false
    });
  };

  var _alertInfo = function(title, text) {
    swal({
      type: 'info',
      title: `${title}`,
      html: `${text}`,
      showConfirmButton: false
    });
  };

  var _alertConfirm = function(title, text, callback) {
    swal({
      reverseButtons: true,
      title: title,
      html: `<h5> ${text} </h5>`,
      type: 'question',
      showCancelButton: true,
      confirmButtonText: 'OK',
      cancelButtonText: 'Cancel'
    }).then(result => {
      if (result.value) {
        callback();
      }
      return;
    });
  };

  return {
    warning: (title, text) => _alertWarning(title, text),
    error: (title, text) => _alertError(title, text),
    success: (title, text) => _alertSuccess(title, text),
    info: (title, text) => _alertInfo(title, text),
    confirm: (title, text, callback) => _alertConfirm(title, text, callback)
  };
})();

// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
  AppExtended.init();
});
