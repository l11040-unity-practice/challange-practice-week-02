using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        spaceAction = actionAsset["Space"];
    }

    [ContextMenu("Rebind")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        var bindingIndex = spaceAction.GetBindingIndexForControl(Keyboard.current.spaceKey);
        if (bindingIndex != -1)
        {
            // spaceAction.ChangeBinding(bindingIndex).Erase();
            // spaceAction.AddBinding("<Keyboard>/excape");
            // spaceAction.ChangeBinding(0);
            spaceAction.ApplyBindingOverride(bindingIndex, "<Keyboard>/excape");
        }

    }

    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
    }

    void OnSpace()
    {
        Debug.Log("test");
    }

    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene2");
    }
}