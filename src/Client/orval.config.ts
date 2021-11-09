import * as faker from 'faker';
import { defineConfig } from 'orval';

export default defineConfig({
  covid: {
    output: {
      mode: 'split',
      target: 'src/api/endpoints/covidFromFileSpecWithTransformer.ts',
      schemas: 'src/api/model',
      client: 'svelte-query',
      mock: true,
      override: {
        mutator: {
          path: 'src/api/mutator/custom-instance.ts',
          name: 'customInstance'
        },
        operations: {
          listPets: {
            mock: {
              properties: () => {
                return {
                  '[].id': () => faker.datatype.number({ min: 1, max: 99999 })
                };
              }
            }
          },
          showPetById: {
            mock: {
              data: () => ({
                id: faker.datatype.number({ min: 1, max: 99 }),
                name: faker.name.firstName(),
                tag: faker.helpers.randomize([faker.datatype.string(), undefined])
              })
            }
          }
        },
        mock: {
          properties: {
            '/tag|name/': () => faker.name.lastName()
          }
        }
      }
    },
    input: {
      target: './swagger.json'
      // override: {
      //   transformer: 'src/api/transformer/add-version.cjs'
      // }
    }
  }
});
