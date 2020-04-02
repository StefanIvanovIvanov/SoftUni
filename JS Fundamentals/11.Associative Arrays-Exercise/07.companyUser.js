function companyUser(input) {
    let companyInfo = {};
    for (let line of input) {
        let splitted = line.split(" -> ");
        let companyName = splitted[0];
        let id = splitted[1];

        if (!companyInfo.hasOwnProperty(companyName)) {
            companyInfo[companyName] = [];
            
        } 
        if (!companyInfo[companyName].includes(id)) {
            companyInfo[companyName].push(id)
        }
    }
    
    let sortedCompanyInfo = Object.entries(companyInfo).sort((a, b) => a[0].localeCompare(b[0]));
    
    for (let company of sortedCompanyInfo) {
        console.log(`${company[0]}`);
        let employeesArr = company[1];
        for (let employee of employeesArr) {
            console.log(`-- ${employee}`);
        }
    }    
}
companyUser([ 'SoftUni -> AA12345',
'SoftUni -> BB12345',
'SoftUni -> BB12345',
'SoftUni -> BB12345',
'Microsoft -> CC12345',
'HP -> BB12345' ]);