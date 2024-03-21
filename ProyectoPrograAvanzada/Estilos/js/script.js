+ function($) {
  $('.palceholder').click(function() {
    $(this).siblings('input').focus();
  });

  $('.form-control').focus(function() {
    $(this).parent().addClass("focused");
  });

  $('.form-control').blur(function() {
    var $this = $(this);
    if ($this.val().length == 0)
      $(this).parent().removeClass("focused");
  });
  $('.form-control').blur();

  // validetion
  $.validator.setDefaults({
    errorElement: 'span',
    errorClass: 'validate-tooltip'
  });

  $("#formvalidate").validate({
    rules: {
      userName: {
        required: true,
        minlength: 6
      },
      userPassword: {
        required: true,
        minlength: 6
          },
          Name: {
              required: true,

          },
          Lastname: {
              required: true,

          },
          Email: {
              required: true,

          },
         Phone: {
              required: true,

          }


    },
    messages: {
      userName: {
        required: "Please enter your username.",
        minlength: "Please provide valid username."
      },
      userPassword: {
        required: "Enter your password to Login.",
        minlength: "Tiene que tener mas de 6 caracteres."
      },
      Name: {
        required: "Enter your Name."
       
      }
        ,
        Lastname: {
            required: "Enter your Lastname."

        }
        ,
        Email: {
            required: "Enter your Email."
   
            ,
            Phone: {
                required: "Enter your Phone."
            }
        }
    }
  });

}(jQuery);