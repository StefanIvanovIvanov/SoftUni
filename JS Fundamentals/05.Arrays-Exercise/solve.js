function solve(input) {
    let array = input.split("|");
  
    let coins = 0;
    let health = 100;
  
    for (let i = 0; i < array.length; i++) {
       let array2 = array[i].split(' ');
  
       for (let j = 0; j < array2.length; j++) {
          if (j == 0) {
             if (array2[j] == `potion`) {
                health += Number(array2[j + 1]);
                if (health > 100) {
                   let diff = health - 100;
                   health = 100;
                   console.log(`You healed for ${(array2[j + 1]) - diff} hp.`);
                } else {
                   console.log(`You healed for ${array2[j + 1]} hp.`);
                }
                console.log(`Current health: ${health} hp.`);
  
             } else if (array2[j] == `chest`) {
                coins += Number(array2[j + 1])
                console.log(`You found ${array2[j + 1]} coins.`);
             } else {
                health -= Number(array2[j + 1]);
                if (health <= 0) {
                   console.log(`You died! Killed by ${array2[j]}.`);
                   console.log(`Best room: ${i+1}`);
                   break;
                }
                console.log(`You slayed ${array2[j]}.`);
             }
          }
       }
       if (health <= 0) {
          break;
       }
    }
    if (health > 0) {
       console.log(`You've made it!`);
      console.log(`Coins: ${coins}`);
      console.log(`Health: ${health}`);
   }
 }

 solve('rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000');