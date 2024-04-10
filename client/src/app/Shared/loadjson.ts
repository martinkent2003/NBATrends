import * as https from 'https';
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
import { Player } from './playerinterface';

// loads json data from parameter url
export function loadJSON(url: string): Promise<any> {
  return new Promise((resolve, reject) => {
    https.get(url, (res) => {
      let data = '';

      res.on('data', (chunk: any) => {
        data += chunk;
      });

      res.on('end', () => {
        resolve(JSON.parse(data)); // Resolve the promise with the parsed JSON data
      });
    }).on('error', (err: Error) => {
      reject(err); // Reject the promise with the error
    });
  });
}

// load json object with player data into players array
function createPlayersArray(data: any[]) {
	const players: Player[] = data.map((playerData: any) => {
		  return {
			  personId: playerData.personId,
			  firstName: playerData.firstName,
			  lastName: playerData.lastName,
			  isActive: playerData.isActive
		  };
	  });
  
	  return players;
	}
  
  // test function - prints first ten players
  function printPlayers(players: Player[])
  {
	console.log("First ten players:");
	for (let i = 0; i < 10; i++) {
		const player = players[i];
		console.log(`Player ${i + 1}:`);
		console.log("  Person ID:", player.personId);
		console.log("  First Name:", player.firstName);
		console.log("  Last Name:", player.lastName);
		console.log("  Active:", player.isActive);
	}
  }

  export async function doSomethingWithPlayers(data: any[]) {
	const players: Player[] = createPlayersArray(data);
	printPlayers(players);
	return players;
  }

  // test - confirms data can be loaded
  loadJSON('https://localhost:5001/api/players')
  .then((data: any[]) => {
    doSomethingWithPlayers(data); 
  })
  .catch(error => {
    console.error('Error fetching data:', error);
  });