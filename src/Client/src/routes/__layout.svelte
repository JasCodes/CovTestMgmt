<script lang="ts" context="module">
	export const ssr = false;
	import 'carbon-components-svelte/css/white.css';
	import { setRole } from '../stores/store';
	import { Header, Content } from 'carbon-components-svelte';
</script>

<div>
	<Header company="Malta" platformName="Covid Test Management" />
	<Content>
		<slot />
	</Content>
</div>

<style>
</style>
