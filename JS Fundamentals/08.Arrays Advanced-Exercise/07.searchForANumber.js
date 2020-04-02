function searchInArr(arr, searchCriteria) {
    let counter = 0;
    arr = arr.map(Number);
    searchCriteria = searchCriteria.map(Number);
    let [takeCount, deleteCount, searchNum] = searchCriteria;
    
    let result = arr.splice(0, takeCount);
    result.splice(0, deleteCount);
    
    for (let el of result) {
        if (el === searchNum) {
            counter++;
        }
    }    
    console.log(`Number ${searchNum} occurs ${counter} times.`);
    
}

searchInArr([5, 2, 3, 4, 1, 6],[5, 2, 3]);