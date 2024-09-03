<script setup lang="ts">
  import {ref} from "vue";

  type Props = {
    label: string,
    options: string[]
  };
  const props = defineProps<Props>();

  const emit = defineEmits<{
    (e: 'select', selectedItem: string): void;
  }>();

  const selectedItem = ref(props.options[0]);

  const reset = () => {
    selectedItem.value = props.options[0];
  };

  defineExpose({reset});
  const fontClasses = "text-[14px] leading-[18px] font-normal";
</script>

<template>
  <div>
    <label :for="label" class="text-[#3B3C3F]" :class="fontClasses">{{ label }}</label>
    <select v-model="selectedItem" :id="label" class="block border rounded-md w-full mt-[8px] py-[8px] px-[12px]" :class="(selectedItem === options[0] ? 'text-[#B6B7B9] ' : '') + fontClasses" @change="emit('select', selectedItem)">
      <option v-for="option in options" :key="option" :value="option" :disabled="options[0] === option">
        {{ option }}
      </option>
    </select>
  </div>
</template>

<style scoped>
select {
  -webkit-appearance: none;
  appearance: none;
}

select {
  background-image: url("../../assets/caretDown.svg");
  background-size: 24px;
  background-repeat: no-repeat;
  background-position: calc(100% - 8px) center;
}
</style>