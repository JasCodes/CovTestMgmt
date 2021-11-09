import { writable } from 'svelte/store';
// import { browser } from '$app/env';
import { onMount } from 'svelte';

export type UserRole = 'admin' | 'user' | 'lab';
const userRoleStore = writable('');

onMount(() => {
  userRoleStore.set(window?.localStorage.getItem('user-role'));

  console.log('userRoleStore', userRoleStore);

  userRoleStore.subscribe((value) => {
    window?.localStorage.setItem('user-role', value);
    console.log(value);
  });
});

export const setRole: (u: UserRole) => () => void = (userRole) => () => userRoleStore.set(userRole);
