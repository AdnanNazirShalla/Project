const modal = document.querySelector(".modal");
const modal1 = document.querySelector(".modal1");
const overlay = document.querySelector(".overlay");

const btnCloseModal = document.querySelector(".btn--close-modal");

const btnCloseModal1 = document.querySelector(".btn--close-modal1");
console.log(btnCloseModal1);
const btnsOpenModal = document.querySelectorAll(".nav--4");
const btnloginmodal = document.querySelectorAll(".nav--3");
console.log(modal1);

document.querySelector(".nav--2").addEventListener("click", function (e) {
    console.log("hello");
    e.preventDefault();

    sections = document.querySelector("#feature--1");

    sections.scrollIntoView({
        behavior: "smooth",
    });
});
const openModal = function (e) {
    e.preventDefault();
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");
};
const openModal1 = function (e) {
    e.preventDefault();
    modal1.classList.remove("hidden");
    overlay.classList.remove("hidden");
};
const closeModal1 = function () {
    modal1.classList.add("hidden");
    overlay.classList.add("hidden");
};
const closeModal = function () {
    modal.classList.add("hidden");
    overlay.classList.add("hidden");
};
btnsOpenModal.forEach((btn) => btn.addEventListener("click", openModal));
btnloginmodal.forEach((btn) => btn.addEventListener("click", openModal1));
btnCloseModal.addEventListener("click", closeModal);
btnCloseModal1.addEventListener("click", closeModal1);
overlay.addEventListener("click", closeModal);
overlay.addEventListener("click", closeModal1);

document.addEventListener("keydown", function (e) {
    if (e.key === "Escape" && !modal.classList.contains("hidden")) {
        closeModal();
    }
});
const form = document.getElementById("form");

const username = document.getElementById("username");
const email = document.getElementById("email");

const password = document.getElementById("password");

const password2 = document.getElementById("password2");
const pin = document.getElementById("pin");
form.addEventListener("submit", (e) => {
    e.preventDefault();

    checkInputs();
    var a = document.getElementById("radio1");
    var b = document.getElementById("radio2");
    var c = document.getElementById("radio3");
    if (a.checked == false && b.checked == false && c.checked == false) {
        alert("select gender");
        return false;
    }
    if (a.checked == true) {
        alert("you are a male");
    } else if (b.checked == true) {
        alert("you are a female");
    } else {
        alert("you are a other");
    }
});

function checkInputs() {
    // trim to remove the whitespaces
    const usernameValue = username.value.trim();
    const emailValue = email.value.trim();

    const passwordValue = password.value.trim();

    const password2Value = password2.value.trim();
    const pinvalue = pin.value.trim();

    if (usernameValue === "") {
        setErrorFor(username, "Username cannot be blank");
    } else {
        setSuccessFor(username);
    }

    if (emailValue === "") {
        setErrorFor(email, "Email cannot be blank");
    } else if (!isEmail(emailValue)) {
        setErrorFor(email, "Not a valid email");
    } else {
        setSuccessFor(email);
    }

    if (passwordValue === "") {
        setErrorFor(password, "Password cannot be blank");
    } else {
        setSuccessFor(password);
    }

    if (pinvalue === "") {
        setErrorFor(pin, "Pin cannot be blank");
    } else {
        setSuccessFor(pin);
    }

    if (password2Value === "") {
        setErrorFor(password2, "Password2 cannot be blank");
    } else if (passwordValue !== password2Value) {
        setErrorFor(password2, "Passwords does not match");
    } else {
        setSuccessFor(password2);
    }
}

function setErrorFor(input, message) {
    const formControl = input.parentElement;
    const small = formControl.querySelector("small");
    formControl.className = "form-control error";
    small.innerText = message;
}

function setSuccessFor(input) {
    const formControl = input.parentElement;
    formControl.className = "form-control success";
}

function isEmail(email) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
        email
    );
}

const email1 = document.getElementById("email1");
const form1 = document.getElementById("form1");
const password1 = document.getElementById("password1");
form1.addEventListener("submit", (e) => {
    e.preventDefault();

    checkInputs1();
});
function checkInputs1() {
    const emailValue1 = email1.value.trim();
    const passwordValue1 = password1.value.trim();

    if (emailValue1 === "") {
        setErrorFor(email1, "Email cannot be blank");
    } else if (!isEmail(emailValue1)) {
        setErrorFor(email1, "Not a valid email");
    } else {
        setSuccessFor(email1);
    }
    if (passwordValue1 === "") {
        setErrorFor(password1, "Password cannot be blank");
    } else {
        setSuccessFor(password1);
    }
}
function setErrorFor(input, message) {
    const formControl = input.parentElement;
    const small = formControl.querySelector("small");
    formControl.className = "form-control error";
    small.innerText = message;
}

function setSuccessFor(input) {
    const formControl = input.parentElement;
    formControl.className = "form-control success";
}
function isEmail(email1) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
        email1
    );
}
