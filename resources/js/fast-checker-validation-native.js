/**
 * fast-checker-validation-native-0.0.1
 */

/**
 * id: string
 * value: string
 * passed: boolean
 */
const validations = [];

let minValidation = 6;

let mainForm, realForm, captcha, realCaptcha, submitButton, realSubmitButton;

/**
 * Set main form id and start listening to submit event.
 * 
 * @param {String} id 
 */
function setMainForm(id) {
    mainForm = `#${id}`;
    realForm = `#real_${id}`;

    listenToSubmit();
}

/**
 * Set captcha field id.
 * 
 * @param {String} formId 
 */
function setCaptchaId(id) {
    captcha = `#${id}`;
    realCaptcha = `#real_${id}`;
}

/**
 * Set submit button id.
 * 
 * @param {String} formId 
 */
function setSubmitButton(id) {
    submitButton = `#${id}`;

    disableSubmitButton();
}

/**
 * Set real submit button id.
 * 
 * @param {String} formId 
 */
function setRealSubmitButton(id) {
    realSubmitButton = `#${id}`;
}

function disableSubmitButton() {
    $(submitButton).prop('disabled', true);
    $(submitButton).css('cursor', 'not-allowed');
}

function enableSubmitButton() {
    $(submitButton).prop('disabled', false);
    $(submitButton).css('cursor', '');
}

function setMinValidation(n) {
    minValidation = n;
}

/**
 * Handle the submit event. If all conditions are met, submit the real form.
 * 
 * @param {Any} e 
 */
function handleSubmit(e) {
    e.preventDefault();

    $(realCaptcha).val($(captcha).val());

    if (!isAllPassed()) {
        alert('Silakan isi form pendaftaran dengan benar.');
        return;
    }

    $(submitButton).val('Mengirim data...');

    $(realSubmitButton).click();

    return;
}

/**
 * Start listening to submit event on the main form.
 */
function listenToSubmit() {
    if (!mainForm) return;

    $(document).on('submit', mainForm, handleSubmit);
}

/**
 * Add new validation item if does not exist.
 * 
 * @param {String} id 
 * @param {String} value 
 * @return {Void}
 */
function addValidation(id, value) {
    const found = validations.find(item => item.id === id);

    if (found) return;

    validations.push({
        id: id,
        value: value,
        passed: false
    });
}

/**
 * Check and set the passed value of a validation item.
 * 
 * @param {String} id 
 * @param {Boolean} passed 
 * @return {Void}
 */
function checkValidation(id, value, passed) {
    const found = validations.find(item => item.id === id);

    if (passed) {
        $(`#real_${id}`).val(value);
    }

    found.value = value;
    found.passed = passed;

    if (isAllPassed()) {
        enableSubmitButton();
    } else {
        disableSubmitButton();
    }
}

/**
 * Check if all validation items has passed.
 * 
 * @return {Void}
 */
function isAllPassed() {
    return validations.length >= minValidation && validations.every(item => item.passed === true);
}
