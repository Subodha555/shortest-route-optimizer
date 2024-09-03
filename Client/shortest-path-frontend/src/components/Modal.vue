<script setup lang="ts">
  import Button from './ui/Button.vue';

  type Props = {
    message: string,
    messageHeader: string,
    messageClasses: string
  }

  const model = defineModel();
  const props = defineProps<Props>();
</script>

<template>
  <Teleport to="body">
    <div v-if="model" class="modal" :class="messageClasses">
      <div class="flex justify-between py-4">
        <div class="text-2xl">{{messageHeader}}</div>
        <Button @click="model = false" buttonClass="bg-[#DA753C] text-white px-[10px] py-[10px] hover:bg-orange-600">Close</Button>
      </div>
      <p>{{message}}</p>
    </div>
  </Teleport>
</template>

<style scoped>
.modal {
  position: fixed;
    z-index: 999;
    top: 36%;
    left: 50%;
    width: 330px;
    margin-left: -150px;
    background: #e7f3ff;
    border-radius: 10px;
    padding: 20px;
    text-align: center;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}
</style>