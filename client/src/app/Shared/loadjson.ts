import * as https from 'https';
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';

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
