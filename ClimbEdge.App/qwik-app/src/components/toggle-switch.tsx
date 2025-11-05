import { component$ } from '@builder.io/qwik';

interface ToggleSwitchProps {
    name: string;
    checked: boolean;
    size?: 'sm' | 'md' | 'lg';
    color?: 'blue' | 'green' | 'yellow' | 'red';
    disabled?: boolean;
}

export default component$<ToggleSwitchProps>((props) => {
    const { name, checked, size = 'md', color = 'blue', disabled = false } = props;

    const sizeClasses = {
        sm: 'w-8 h-4',
        md: 'w-11 h-6',
        lg: 'w-14 h-8'
    };

    const afterSizeClasses = {
        sm: 'after:h-3 after:w-3',
        md: 'after:h-5 after:w-5',
        lg: 'after:h-7 after:w-7'
    };

    const colorClasses = {
        blue: 'peer-checked:bg-blue-600 peer-focus:ring-blue-300',
        green: 'peer-checked:bg-green-600 peer-focus:ring-green-300',
        yellow: 'peer-checked:bg-yellow-600 peer-focus:ring-yellow-300',
        red: 'peer-checked:bg-red-600 peer-focus:ring-red-300'
    };

    return (
        <label class={`relative inline-flex items-center cursor-pointer ${disabled ? 'opacity-50 cursor-not-allowed' : ''}`}>
            <input
                type="checkbox"
                name={name}
                checked={checked}
                disabled={disabled}
                class="sr-only peer"
            />
            <div class={`
                ${sizeClasses[size]} 
                bg-gray-200 
                peer-focus:outline-none 
                peer-focus:ring-4 
                ${colorClasses[color]}
                rounded-full 
                peer 
                peer-checked:after:translate-x-full 
                peer-checked:after:border-white 
                after:content-[''] 
                after:absolute 
                after:top-[2px] 
                after:left-[2px] 
                after:bg-white 
                after:border-gray-300 
                after:border 
                after:rounded-full 
                ${afterSizeClasses[size]}
                after:transition-all
            `}></div>
        </label>
    );
});
