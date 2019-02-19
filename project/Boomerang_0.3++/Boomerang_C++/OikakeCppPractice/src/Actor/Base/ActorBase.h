#pragma once

class Renderer;
class HitInfo;
#include "ActorPtr.h"
#include "Status.h"
#include"EventMessage.h"
#include"ActorGroup.h"
#include"World/IWorld.h"
#include<string>
#include<functional>
#include<list>

class ActorBase {
public:
	ActorBase();
	ActorBase(IWorld* world, const std::string& name);
	explicit ActorBase(const std::string& name);
	virtual ~ActorBase();
public:

	void Initialize();
	void Update(float deltaTime);
	void Draw(Renderer& renderer);
	void DrawShadow(Renderer& renderer);
	void Finalize();
	void HandleMessage(EventMessage message, void* param);

	void Collide(ActorBase& other);
	void CollideChildren(ActorBase& other);
	void CollideSibling();


	void AddChild_Front(const ActorPtr& actor);
	void AddChild_Front(ActorGroup group, const ActorPtr& actor);
	void AddChild_Back(const ActorPtr& actor);
	void AddChild_Back(ActorGroup group, const ActorPtr& actor);
	void EachChildren(std::function<void(ActorBase&)> func);
	void EachChildren(std::function<void(const ActorBase&)> func) const;
	void RemoveChildren(std::function<bool(ActorBase& actor)> func);
	void RemoveChildren();
	ActorPtr FindChildren(std::function<bool(const ActorBase&)> func);
	ActorPtr FindChildren(const std::string& name);
	void ChangeStatus(Status status);
	Status GetStatus() const;
	std::string GetName() const;
	void ClearChildren();
	std::list<ActorPtr>& GetChildren();
	int GetChildNum() const;
protected:
	virtual void OnInitialize();
	virtual void OnUpdate(float deltaTime);
	virtual void OnDraw(Renderer& renderer);
	virtual void OnDrawShadow(Renderer& renderer);
	virtual void OnFinalize();
	virtual void OnMessage(EventMessage message, void* param);
	virtual bool IsCollide(const ActorBase& other, HitInfo& hitInfo);
	virtual void OnCollide(const HitInfo& hitInfo);
protected:
	IWorld* world;
	std::string name;
	Status	status;
private:
	std::list<ActorPtr> children;
private:
	//ÉRÉsÅ[ã÷é~
	ActorBase(const ActorBase& other) = delete;
	ActorBase& operator = (const ActorBase& other) = delete;
};