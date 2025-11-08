// Register a custom validator for valid USD
$.validator.addMethod("validusd", function (value, element) {
    if (value === "") return true; //handle instances of empty values

    const regex = /^\d+(\.\d{1,2})?$/; // matches non-negative numbers with up to 2 decimal places
    return regex.test(value);
});

// Hook into unobtrusive validation
$.validator.unobtrusive.adapters.addBool("validusd");