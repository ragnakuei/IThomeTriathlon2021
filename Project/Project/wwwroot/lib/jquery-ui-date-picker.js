const jquery_ui_date_picker = {
    template: `
        <input type="text" 
               v-bind:id="id"
               v-model="dom_value" />
    `,
    props: {
        id: String,
        date_format: String,
        modelValue: String,
    },
    setup(props, {emit}) {

        let dom = null;

        onMounted(() => {
            dom = $("#"+ props.id);
            dom.datepicker({
                dateFormat: props.date_format || "yy-mm-dd",
                onClose : function (dateText, inst) {
                    dom_value.value = dateText;
                }
            });
        })

        const dom_value = computed({
            get: () => {
                return props.modelValue?.split('T')[0];
            },
            set: (v) => {
                if (v === "")
                {
                    v = null;
                }

                emit('update:modelValue', v);
            },
        });

        return {
            dom_value,
        }
    },
}
