<script setup lang=ts>
import Header from './components/Header.vue';
import SelectPathForm from './components/SelectPathForm.vue';
</script>

<template>
  <div class="wrapper h-screen flex flex-col">
    <Header/>
    <div class="content-container flex-1 flex justify-center">
      <SelectPathForm/>
    </div>
  </div>
</template>

<style>

.wrapper {
  background: linear-gradient(to bottom,
  #1154A3 41%, #E7F3FF 41%);
  min-width: 360px;
}

body {
  margin: 0;
  font-family: 'Poppins',serif;
  background-color: #E7F3FF;
}
</style>
