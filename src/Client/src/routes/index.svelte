<script lang="ts" context="module" >
  export const ssr = false;
  import { setRole } from './../stores/store';
  import { Button, Grid, Row, Column } from 'carbon-components-svelte';
  import {usePostApiV1Login} from '../api/endpoints/covidFromFileSpecWithTransformer';
  
  // const login= usePostApiV1Login({mutation:{onMutate:{vari}}});
  
  // api.postApiV1Login({Phone:"1"}).then(res => {
  //   console.log(res);
  //   // setRole(res.data.role);
  // });

</script>

<Grid padding={true}>
  <Row>
    <Column>
      <!-- {#if $login.isLoading}
   <span>Loading...</span>
 {:else if $login.error}
   <span>An error has occurred: {$login.error.title}</span>
 {:else}
   <div>
     <h1>{$login.data}</h1>
   </div>
 {/if} -->

    </Column>
    <Column>
      <Button href="/grid" on:click={setRole('user')}>User</Button>
    </Column>
    <Column>
      <Button href="/grid" on:click={setRole('admin')}>Admin</Button>
    </Column>
    <Column>
      <Button href="/grid" on:click={setRole('lab')}>Lab</Button>
    </Column>
  </Row>
</Grid>

<style>
</style>
