$("#empRegister").kendoForm({
  validatable: {
    validateOnBlur: true,
    // Show all error messages in a single validation summary
    // validationSummary: true,
    errorTemplate: "<span class='text text-danger'>#=message#</span>",
  },
  formData: {
    c_empName: "",
    c_empEmail: "",
    c_empPwd: "",
  },
  items: [
    {
      field: "c_empName",
      label: "Employee Name",
      validation: {
        required: {
          message: "Please enter name.",
        },
      },
    },
    {
      field: "c_empEmail",
      label: "Employee Email",
      validation: {
        required: {
          message: "Please enter email address.",
        },
        customEmailValidation: function (input) {
          if (input.is("[name='c_empEmail']")) {
            var emailPattern =/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            if (!emailPattern.test(input.val())) {
              input.attr(
                "data-customEmailValidation-msg",
                "Please enter a valid email address."
              );
              return false;
            }
          }
          return true;
        },
      },
    },
    {
        field: "c_empPwd",
        label: "Employee password",
        validation:{
            required: {
                message: "Please enter your password."
            },
            pwdLenght: function(input){
                if(input.is("[name='c_empPwd']")){
                    if((input.val()).length < 8)
                    {
                        input.attr("data-pwdLenght-msg","Password length must be 8 charcter long");
                        return false;
                    }
                }
                return true
            }
        }
        
    },
    {
        field: "c_empConfPwd",
        label: "Confirm Password",
        validation:{
            required: {
                message: "Please enter confirm password."
            },
            comparePwd: function(input){
                if(input.is("[name='c_empConfPwd']")){
                    if($("[name='c_empPwd']").val() != input.val())
                    {
                        input.attr("data-comparePwd-msg","Confirm password is not match.");
                        return false;
                    }
                }
                return true
            }
        }
    }
  ],
});
