	//Validtion Code For Inputs

var Name = document.forms['form']['Name'];
var Phone = document.forms['form']['Phone'];

Name.addEventListener('textInput', Name_Verify);
Phone.addEventListener('textInput', Phone_Verify);

function validated(){
	if (Name.value.length < 9) {
		Name.style.border = "1px solid red";
		Name_error.style.display = "block";
		Name.focus();
		return false;
	}
	if (Phone.value.length < 6) {
		Phone.style.border = "1px solid red";
		Phone_error.style.display = "block";
		Phone.focus();
		return false;
	}

}
function email_Verify(){
	if (Name.value.length >= 8) {
		Name.style.border = "1px solid silver";
		Name_error.style.display = "none";
		return true;
	}
}
function Phone_Verify(){
	if (Phone.value.length >= 5) {
		Phone.style.border = "1px solid silver";
		Phone_error.style.display = "none";
		return true;
	}
}

