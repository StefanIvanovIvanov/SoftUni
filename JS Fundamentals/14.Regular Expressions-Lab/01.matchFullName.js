function matchFullName(arr) {
    let text = arr[0];
    let pattern = /\b[A-Z][a-z]+ [A-Z][a-z]+\b/g;
    let validNames = text.match(pattern);
    console.log(validNames.join(' '));
}

matchFullName([ 'Ivan Ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Test Testov, Ivan\tIvanov' ]);