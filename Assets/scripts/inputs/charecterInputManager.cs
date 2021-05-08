using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charecterInputManager : MonoBehaviour
{
    public charecterController m_controler;
    private Controls m_controls;
    private Vector2 m_moveDirection;
    private int m_itemIdx = 0;

    private void OnEnable()
    {
        m_controls = new Controls();
        m_controls.charecter.Move.performed += HandleMove;
        m_controls.charecter.Move.canceled += HandleMove;
        m_controls.charecter.ActivateMenu.performed += ActivateInGameMenu;
        m_controls.charecter.ActivateMenu.Enable();
        m_controls.charecter.Move.Enable();
        m_controls.charecter.Use.performed += UseObject;
        m_controls.charecter.Use.Enable();
        m_controls.charecter.ChangeItem.performed += HandleChangeItem;
        m_controls.charecter.ChangeItem.Enable();
        m_controls.charecter.Interact.performed += interactWithObject;
        m_controls.charecter.Interact.Enable();
    }
    
    private void FixedUpdate()
    {
        m_controler.Move(m_moveDirection);
    }

    private void OnDisable()
    {
        m_controls.charecter.ActivateMenu.performed -= ActivateInGameMenu;
        m_controls.charecter.Move.performed -= HandleMove;
        m_controls.charecter.Move.canceled -= HandleMove;
        m_controls.charecter.ActivateMenu.Disable();
        m_controls.charecter.Move.Disable();
        m_controls.charecter.Use.performed -= UseObject;
        m_controls.charecter.Use.Disable();
        m_controls.charecter.ChangeItem.performed -= HandleChangeItem;
        m_controls.charecter.ChangeItem.Disable();
        m_controls.charecter.Interact.performed -= interactWithObject;
        m_controls.charecter.Interact.Disable();
    }

    private void ActivateInGameMenu(InputAction.CallbackContext context)
    {
        Debug.LogError("escape pressed");
        MenuManager menuManager = FindObjectOfType<MenuManager>();
        if(menuManager == null)
        {
            Debug.LogError("MenuManager couldnt be found");
            return;
        }
        menuManager.activateInGameMenu();
    }
    private void HandleMove(InputAction.CallbackContext context) 
    {
        m_moveDirection = context.ReadValue<Vector2>();
        m_controler.Move(m_moveDirection);
    }

    public void UseObject(InputAction.CallbackContext context)
    {
        m_controler.UseItem();
    }

    private void HandleChangeItem(InputAction.CallbackContext context) 
    {
        int inventoryChangeDirection = (int)context.ReadValue<float>();
        if(m_controler.changeItem(m_itemIdx + inventoryChangeDirection)) 
        {
            m_itemIdx += inventoryChangeDirection;
        }
    }

    private void interactWithObject(InputAction.CallbackContext context) 
    {
        m_controler.interactWithObject();
    }

}
