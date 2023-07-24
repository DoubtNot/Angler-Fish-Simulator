using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public GameObject loadingScreen; // Reference to the loading screen GameObject

    public Button createButton; // Reference to the Create Room button
    public Button joinButton; // Reference to the Join Room button
    public Button titleButton;
    public Button backButton;

    private TextMeshProUGUI createInputText; // Reference to the Text component of the createInput
    private TextMeshProUGUI joinInputText; // Reference to the Text component of the joinInput
    private TextMeshProUGUI createPlaceholderText; // Reference to the Placeholder component of the createInput
    private TextMeshProUGUI joinPlaceholderText; // Reference to the Placeholder component of the joinInput
    private TextMeshProUGUI createButtonText; // Reference to the Text component of the createButton
    private TextMeshProUGUI joinButtonText; // Reference to the Text component of the joinButton

    private bool isJoiningRoom = false; // Flag to track if the player is attempting to join a room


    private void Start()
    {
        // Get the TextMeshProUGUI and Placeholder components
        createInputText = (TextMeshProUGUI)createInput.textComponent;
        joinInputText = (TextMeshProUGUI)joinInput.textComponent;
        createButtonText = createButton.GetComponentInChildren<TextMeshProUGUI>();
        joinButtonText = joinButton.GetComponentInChildren<TextMeshProUGUI>();
        createPlaceholderText = createInput.placeholder.GetComponent<TextMeshProUGUI>();
        joinPlaceholderText = joinInput.placeholder.GetComponent<TextMeshProUGUI>();
    }

    public void CreateRoom()
    {
        if (createInput.text.Length >= 1)
        {
            StartCoroutine(CreateRoomCoroutine());
        }
    }

    private IEnumerator CreateRoomCoroutine()
    {
        loadingScreen.SetActive(true); // Show the loading screen

        // Disable the buttons and input fields during network operation
        createButton.interactable = false;
        joinButton.interactable = false;
        createInput.interactable = false;
        joinInput.interactable = false;
        titleButton.interactable = false;
        backButton.interactable = false;

        // Hide the text in the input fields and buttons (set alpha to 0)
        createInputText.alpha = 0.0f;
        joinInputText.alpha = 0.0f;
        createButtonText.alpha = 0.0f;
        joinButtonText.alpha = 0.0f;
        createPlaceholderText.alpha = 0.0f;
        joinPlaceholderText.alpha = 0.0f;

        // Create the room and wait for the response
        PhotonNetwork.CreateRoom(createInput.text);

        // Wait for the network operation to complete (You may need to modify the condition based on your needs)
        while (!PhotonNetwork.InRoom)
        {
            yield return null;
        }

        // Load the multiplayer map scene
        PhotonNetwork.LoadLevel("Map_Multiplayer");
    }

    public void JoinRoom()
    {
        if (joinInput.text.Length >= 1 && !isJoiningRoom)
        {
            StartCoroutine(JoinRoomCoroutine(joinInput.text));
        }
    }

    private IEnumerator JoinRoomCoroutine(string roomName)
    {
        isJoiningRoom = true; // Set the flag to true to prevent multiple attempts to join


        loadingScreen.SetActive(true); // Show the loading screen

        // Disable the buttons and input fields during network operation
        createButton.interactable = false;
        joinButton.interactable = false;
        createInput.interactable = false;
        joinInput.interactable = false;
        titleButton.interactable = false;
        backButton.interactable = false;

        // Hide the text in the input fields and buttons (set alpha to 0)
        createInputText.alpha = 0.0f;
        joinInputText.alpha = 0.0f;
        createButtonText.alpha = 0.0f;
        joinButtonText.alpha = 0.0f;
        createPlaceholderText.alpha = 0.0f;
        joinPlaceholderText.alpha = 0.0f;

        // Join the room and wait for the response
        PhotonNetwork.JoinRoom(joinInput.text);

        // Wait for the network operation to complete (You may need to modify the condition based on your needs)
        while (!PhotonNetwork.InRoom)
        {
            yield return null;
        }

        OnJoinedRoom();
    }

    public override void OnJoinedRoom()
    {
        // You can optionally handle the room join event here, if needed.
        PhotonNetwork.LoadLevel("Map_Multiplayer"); // Moved to the coroutine
    }
}
