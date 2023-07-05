using UnityEngine;
using System.Collections;

public class DragRigidbody : MonoBehaviour
{

	public float force = 50; // ���� ������
	public float sensitivity = 25; // ����������� �������� ��� ����������� �������
	public float heightValue = 0.35f; // ���������������� ��� ��������� ������ ��������� �����
	public float heightValueMax = 2; // ��������� ����� ������� ������, ������������ ��������� �����
	public float heightValueMin = 1; // ��������� ����� �������� ������, ������������ ��������� �����
	public float distance = 5; // ������������ ���������, � ������� ����� �������� ������
	public float maxMass = 10; // ������������ ����� �������, ������� ����� �������
	public float stopDistance = 1; // ���������� ���������� �� ����� ���������� � �������� ��������� �������, ��� ����������� (����� ������ ���� ���������� ������� ������ �������)

	private Rigidbody body;
	private float mass, curHeight, curRotation, curForce;
	private Transform clone, local;
	private static bool _get;

	public static bool isDrag
	{
		get { return _get; }
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			body = GetRigidbody();
		}
		else if (Input.GetMouseButtonUp(1) && body)
		{
			Clear();
		}
		else if (Input.GetMouseButtonDown(2) && body)
		{
			Rigidbody tmpBody = body;
			Clear();
			tmpBody.velocity = Camera.main.transform.TransformDirection(Vector3.forward) * curForce;
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0 && body)
		{
			NewHeight(heightValue);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0 && body)
		{
			NewHeight(-heightValue);
		}
	}

	void NewHeight(float value) // ��������� ������
	{
		curHeight += value;
		curHeight = Mathf.Clamp(curHeight, heightValueMin, heightValueMax);
		if (curHeight == heightValueMin || curHeight == heightValueMax) return;
		clone.position += new Vector3(0, value, 0);
	}

	Rigidbody GetRigidbody()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		if (Physics.Raycast(ray, out hit, distance))
		{
			if (hit.rigidbody && !hit.rigidbody.isKinematic && hit.rigidbody.mass <= maxMass)
			{
				mass = hit.rigidbody.mass;
				if (mass < 2) mass = 2; // ���� ������, ������� �� �����, ������� ���������, ����� ����������� ����� �� ���� ����� ��� ������ �������
				curForce = force / mass;
				hit.rigidbody.useGravity = false;
				hit.rigidbody.freezeRotation = true;
				clone.position = hit.point; // ������������� �����, ��� "����������" ������
				return hit.rigidbody;
			}
		}
		return null;
	}

	void SetLocal() // �������� ������� � ��������, ���������
	{
		if (_get) return;
		local.rotation = body.rotation;
		local.position = body.position;
		_get = true;
	}

	float RoundTo(float f, int to) // ��������� ��
	{
		return ((int)(f * to)) / (float)to;
	}

	void FixedUpdate()
	{
		if (!body) return;

		Vector3 lookAt = Camera.main.transform.position;
		lookAt.y = clone.position.y;
		clone.LookAt(lookAt);
		SetLocal();
		body.velocity = (local.position - body.position) * sensitivity;
		body.rotation = local.rotation;

		float dist = Vector3.Distance(body.position, local.position);
		dist = RoundTo(dist, 100); // ��������� �� �����, ��� ���������� ������������
		if (dist > stopDistance) // �����, ��� ������� ��������� ������� ������ ����� ��� ���� ����� ��������� ������
		{
			body.velocity = Vector3.zero; // ������������ ����� ��������, ����� ������ ����� ������� � �����������
			Clear();
		}
	}

	void CheckVelocity() // �������� ��������, ����� �� ��������� ������ �� ����� �������� ������, ����� ��� �������� �� ����� ��������� ���� ������
	{
		Vector3 velocity = body.velocity.normalized * curForce;
		if (body.velocity.sqrMagnitude > velocity.sqrMagnitude)
		{
			body.velocity = velocity;
		}
	}

	void Clear()
	{
		curHeight = 0;
		_get = false;
		clone.localPosition = Vector3.zero;
		local.localPosition = Vector3.zero;
		if (!body) return;
		CheckVelocity();
		body.useGravity = true;
		body.freezeRotation = false;
		body = null;
	}

	void Start()
	{
		if (!clone) // �������� ��������������� �����
		{
			local = new GameObject().transform;
			clone = new GameObject().transform;
			local.parent = clone;
			clone.parent = Camera.main.transform;
		}

		heightValueMin = -Mathf.Abs(heightValueMin);
		heightValueMax = Mathf.Abs(heightValueMax);

		Clear();
	}
}
